    public class MyObject<T>
        where T: struct
    {
        public MyObject(T original)
        {
        }
    }
    var c1 = new MyObject<int>(1);
    // or
    var c2 = new MyObject<Int32>(2);
