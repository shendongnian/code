    public class ObjectState
    {
      public int ID { get; set; }
      public string Description { get; set; }
    }//should really be immutable
     //should also implement IEquatable<ObjectState> for equality
    public static readonly State_Open = new ObjectState()
      { ID = 1, Description = "Open" }
    public static readonly State_Closed = new ObjectState() 
      { ID = 2, Description = "Closed" }
    public static class DoorStatus
    { 
       public static readonly ObjectState Open = State_Open;
       public static readonly ObjectState Closed = State_Closed; 
    }
    //and WindowStatus if you want.
    
    public class Door {
      public ObjectState State { get; set; }
    } //or perhaps refactor to a shared base/interface StatefulObject
 
