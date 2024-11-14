namespace LinqJoin
{
    public class Program
    {
        public class Author
        {
            public int AuthorId { get; set; }
            public string Name { get; set; }

        }

        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public int AuthorId { get; set; }
        }
        static void Main(string[] args)
        {
            List<Author> authors = new List<Author>() // yazar listesi oluşturuldu
            { 
            new Author{AuthorId =1 , Name= "Orhan Pamuk"},
            new Author{AuthorId =2 , Name="Elif Şafak" },
            new Author{AuthorId =3 , Name="Ahmet Ümit"}
            };
            List<Book> books = new List<Book> // kitap listesi oluşturuldu
            {
            new Book { BookId = 1, Title = "Kar", AuthorId = 1 },
            new Book { BookId = 2, Title = "İstanbul", AuthorId = 1 },
            new Book { BookId = 3, Title = "10 Minutes 38 Seconds in This Strange World", AuthorId = 2 },
            new Book { BookId = 4, Title ="Beyoğlu Rapsodisi", AuthorId = 3 }
            };
            // authors tablosunda bulunan authorId ile book tablosunda bulunan authorId join ile birleştirilmiştir. 
            var sonuc = authors.Join(books, 
                                     author => author.AuthorId, 
                                     book => book.AuthorId, 
                                     (author, book) => new
            {
                AuthorName = author.Name,
                BookTitle = book.Title
            }
               );

            foreach (var item in sonuc ) 
            {
                Console.WriteLine($" Author : {item.AuthorName},Book : {item.BookTitle}");
            }
        }
    }
}
