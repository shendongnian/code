     public class NewsItem
    {
        public virtual int Id { get; set; }
        public virtual string NewsTitle { get; set; }
        public virtual string NewsContent { get; set; }
        public virtual string NewsImage { get; set; } //string instead of byte because you don't wanna store your whole image file in your database, but just the path of the image, and the image you will store in a folder somewhere on the server
        public virtual DateTime DateAdded { get; set; }
        public virtual bool IsLive { get; set; }
    }
