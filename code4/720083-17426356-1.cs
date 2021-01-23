    public abstract class Base
    {
       protected Base()
       {
          if (!(this is A || this is B))
             // throw an exception
       }
    }
