    public class Base 
    {
      private Thing thing;
      private BaseId id;
      internal BaseId Id
      {
        get
        {
          return this.thing == null ? this.id : this.thing.GetId();
        }
      }
    }
    public class Child
    {
      public ChildId ChildId
      {
        get 
        { 
          return (ChildId) this.Id; 
        }
      }
    }
