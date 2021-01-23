    public class Admin
    {
        public void Maine()
        {
            List<Books> myLibraryBooks = new List<Books>();
    
            Books book1 = new Books();
    
            Console.Write("Enter Author Name:");
            book1.Author = Console.ReadLine();
    
            Console.Write("Enter Book Title:");
            book1.Title = Console.ReadLine();
    
            Console.Write("Enter Book ISBN:");
            book1.ISBN = Console.ReadLine();
    
            Console.Write("Enter the Publish Date:");
            book1.Publish_Date = Console.ReadLine();
    
            myLibraryBooks.Add(book1);
            Console.WriteLine("Book added Successfully");
    
    
            Console.Write("Enter Author's Name:");
            string input_to_find = Console.ReadLine();
            
            var author = from Authors in myLibraryBooks
                         where Authors.Author.ToLower().Equals(input_to_find.ToLower())
                         select Authors;
    
            foreach (var book in author)
            {
                 Console.WriteLine(String.Format("{0} - {1} - {2} - {3}", book.Author, book.Title, book.ISBN, book.Publish_Date));
            }
    
        }
    
        class Books
        {
            public string Author { get; set; }
            public string Title { get; set; }
            public string ISBN { get; set; }
            public string Publish_Date { get; set; }
        }
    }
