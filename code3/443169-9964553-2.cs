    public class Rooms
    {
      public Session ParentSession { set;get;}
      
      public Rooms(Session parent)
      {
        this.ParentSession=parent;
      }
    
      public void Load() {}
    }
