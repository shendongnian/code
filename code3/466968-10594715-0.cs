    public IList<Entry> ParseEntryFile(string fileName)
    {
        ...
        var entries = new List<Entry>();
     
        foreach(var line in file)
        {
            var entry = new Entry();
            ...
            entries.Add(entry);
        }
        return entries;
    }
    
    
    public class Entry
    {
        public Book BookEntry { get; set; }
        public Author AuthorEntry { get; set; }
        public Journal JournalEntry { get; set; }
    }
    
    public class Book
    {
        public string Name{ get; set; }
        ...
    }
    
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    ...
