    public class Customer
    {
      public int ID { set;get;}
      public string JsonData { set;get;}
      [NotMapped]
      public ICollection<string> Items { set;get;}
    }
