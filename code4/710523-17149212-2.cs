    public class MyObject<T>
        where T: IComparable
    {
        public MyObject(T original)
        {
            // do runtime check
        }
    }
    var c1 = new MyObject<int>(1);
    // or
    var c2 = new MyObject<Int32>(2);
