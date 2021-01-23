    public class Shelve
    {
        public int Id{get;set;}
        public string Name{get;set}
        ....//some other properties, as example address in library
        public virtual ICollection<Book> Books{get;set;}
    }
