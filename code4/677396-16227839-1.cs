    public class B {
      private A<int> intVal;
      public int IntVal{
        get{
          return intVal.obj;
        }
        set{
          intVal.obj = value;
        }
      }
      // same for stringval
    }
