    public class Book
    {
        public string Name { get; set; }
        public int Pages { get; set; }
    }    
    
    [Test]
    public void TestBooks()
    {
        var listOfNumbers = new List<Book>() {new Book(){Pages = 10}, new Book(){Pages = 44}};
        var result = listOfNumbers.Between(x => x.Pages, 0, 29);
    }
