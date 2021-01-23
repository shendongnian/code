    public class User
    {
      public int UserID { set;get;}
      public string Name { set;get;}
      public string Email{ set;get;}
      public virtual IEnumerable<Work> Works { set;get;}
    }
    
    public class Work
    {
      public int WorkID { set;get;}
      public string WorkName { set;get;}
      public string Hours { set;get;}
      public string Location { set;get;}
    }
