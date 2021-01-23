    public class MyEntity
    {
        public DateTime DateUpdated { get; private set; }
        public string Author { get; private set; }
        public string Comment { get; private set; }
    
        public void AddComment(string comment, string author)
        {
            Author = author;
            Comment = comment;
            DateUpdated = DateTime.Now;
        }
        public void AddComment(string comment, string author, DateTime dateUpdated)
        {
            Author = author;
            Comment = comment;
            DateUpdated = dateUpdated;
        }
    }
