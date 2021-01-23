    public class Tracker
    {
      public static List<object> AllObjects = new List<object>();
    }
    public class ClassA
    {
       public ClassA()
       {
          Tracker.AllObjects.Add(this);
       }
       ...
    }
