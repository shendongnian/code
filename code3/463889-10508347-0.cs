    public class Foo
    {
       private int actual = 0;
       public int Bar
       {
          get { return actual++; }
          set { value = actual; value++ }
       }
    }
    int v = foo.Bar; //0
    v = foo.Bar; // 1
    v = foo.Bar; // 2
    foo.Bar = v; // actual = 3
