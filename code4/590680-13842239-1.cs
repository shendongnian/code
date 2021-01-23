    public class MyClass {
       public MyClass(string p1 = null, int p2 = 10, ...) { }
    }
    //...
    var o = Activator.CreateInstance(typeof(MyClass)); //<-- will fail
