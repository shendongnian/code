    public class Session
    {
      public Rooms SessionRooms { set;get;}
      public Details SessionDetails { set;get;}
      
      public Session()
      {
        if(this.SessionRooms==null)
        {
          this.SessionRooms=new Room(this);
        }
        if(this.SessionDetails ==null)
        {
          this.SessionDetails =new Details(this);
        }
      }
    }
