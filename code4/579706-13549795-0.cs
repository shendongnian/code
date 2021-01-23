    public class MyObject
    {
        public string Property { get; set; }
        public MyObject(string property)
        {
            this.Property = property;
        }
        public static MyObject operator +(MyObject a1, MyObject a2)
        {
            return new MyObject(a1.Property + a2.Property);
        }
    }
        MyObject o1 = new MyObject("Hello");
        MyObject o2 = new MyObject(" World!");
        MyObject o3 = o1 + o2;
 
