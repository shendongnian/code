    public abstract class EventClass : IEventRepository
    {
      public abstract int Method1(string str);
      public int Method2(string str)
      {
        return 2;
      }
    }
    
    public class EventClass1 : EventClass
    {
      public override int Method1(string str)
      {
        return 1;
      }
    }
    public class EventClass2 : EventClass
    {
      public override int Method1(string str)
      {
        return -1;
      }
    }
