    void Main()
    {
    	List<Pet> petList = new List<Pet>();
    			petList.Add(new Pet() { Name = "Mr.", Species = "Dog" });
    			petList.Add(new Pet() { Name = "Mrs.", Species = "Cat" });
    			petList.Add(new Pet() { Name = "Mayor", Species = "Sloth" });
    			petList.Add(new Pet() { Name = "Junior", Species = "Rabbit" });
    	
    	
    	List<Book> bookList = new List<Book>();
    			bookList.Add(new Book() { Author = "Me", PageCount = 100, Title = "MyBook" });
    			bookList.Add(new Book() { Author = "You", PageCount = 200, Title = "YourBook" });
    			bookList.Add(new Book() { Author = "Pat", PageCount = 300, Title = "PatsBook" });
    	
    	List<object> both = petList.OfType<object>().Union(bookList.OfType<object>()).ToList().Dump();
    }
    
    // Define other methods and classes here
    public class Pet
    {
      public string Name { get; set; }
      public string Species { get; set; }
    }
    public class Book
    {
      public string Author { get; set; }
      public int PageCount { get; set; }
      public string Title { get; set; }
    }
      
