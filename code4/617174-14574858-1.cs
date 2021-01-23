    private const string FILE_PATH = "Librarybooks.txt";
    
    static void addbook()
    {
        //Here is where I get my strings that I will write
    
        Console.Write("Book Title:");
        string title = Console.ReadLine();
    
        Console.Write("ISBN#:");
        string isbn = Console.ReadLine();
    
        Console.Write("Author:");
        string author = Console.ReadLine();
    
        Console.Write("Publish Date:");
        string publish_date = Console.ReadLine();
    
        //Here Is where I create the Stream Reader and Writer
        //And where I write to the file
        using (var fs = File.Open(FILE_PATH, FileMode.OpenOrCreate,FileAccess.ReadWrite))
        {
            using (var sw = new StreamWriter(fs))
            {
                using (var sr = new StreamReader(fs))
                {
                    sw.WriteLine(title.ToCharArray());
                    sw.WriteLine(isbn.ToCharArray());
                    sw.WriteLine(author.ToCharArray());
                    sw.WriteLine(publish_date.ToCharArray());
    
                    Console.WriteLine("Book added Successfully!!");
                 }
             }
         }
    }
    
    static void list_books()
    {
        using (StreamReader sr = new StreamReader(FILE_PATH))
        {
           string fileContent = sr.ReadToEnd();
        }
    }
