    public class UserWork
    {
      public int UserWorkID { set;get;}
      public int UserID { set;get}
      public int WorkID { set;get;} 
      public virtual User User { set;get;}
      public virtual Work Work  {set;get;}
    }
