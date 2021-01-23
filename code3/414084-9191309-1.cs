    public class Blog
    {
       public int id { get; set; }
       public string Subject { get; set; }
       public string Body { get; set; }
       public virtual Person Owner { get; set; }
    }
