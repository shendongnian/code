    public class MyClass
    {
        static int Capacity = 100;
        static List<MyObj> MyObjs = new List<MyObj>(Capacity);
        static MyClass() {
           for( var i = 0; i < Capacity; i++ ) {
              MyObjs.Add(new MyObj());
           }
        }
    }
