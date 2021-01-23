    public class Book
    {
        public int Id{get;set;}
        public string Title{get;set;}
        ....//some other properites
        public virtual Shelve Shelve{get;set;} //navigation property to Shelve where this book is placed
    }
