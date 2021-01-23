    public interface IEventRepository
    {
      int Method1(string str);
      int Method2(string str);
    }
    
    public class EventClass1 : IEventRepository
    {
      public int Method1(string str)//can't be overridden as not marked virtual
      {
        return 1;
      }
      public virtual int Method2(string str)//can be overridden
      {
        return 2;
      }
    }
    
    public class EventClass2 : EventClass1
    {
      public override int Method2(string str)
      {
        return -2;
      }
    }
