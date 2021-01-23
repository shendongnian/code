    class Person
    {
      public int ID { get; set; }
    }
    class Content
    {
      public int ID { get; set; }
    }
    class Image : Content
    {
      public bool IsPrivate { get; set; }   
      public virtual Person Author { get; set; }
    }
    class Tag
    {
    public int ID { get; set; }
    public Content Content { get; set; }
    public Person Person { get; set; }
    }
