    internal abstract class Base
    {
       public Dictionary<int, string> Entities { get; private set; }
       protected Base()
       {
          Entities = new Dictionary<int, string>();
       }
    }
