    public class EventClass1 : IEventRepository
    {
      public int Method1(string str)//not override-able
      {
        return 1;
      }
      public int Method2(string str)//not override-able
      {
        return 2;
      }
    }
    public class EventClass2 : EventClass1, IEventRepository
    {
      //We really want our own Method1!
      public new int Method1(string str)
      {
        return 3;
      }
      int IEventRepository.Method1(string str)
      {
        return -1;
      }
    }
    EventClass2 e2 = new EventClass2();
    EventClass1 e1 = e2;
    IEventRepository ie = e2;
    Console.WriteLine(e2.Method1(null));//3
    Console.WriteLine(e1.Method1(null));//1
    Console.WriteLine(ie.Method1(null));//-1
