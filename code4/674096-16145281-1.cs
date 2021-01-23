    public class Article
    {
        public int ID { get; set; }
        public virtual IEnumerable<Visit> Visits { get; set; }
    }
