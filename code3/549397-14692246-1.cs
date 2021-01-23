    // Using my above method...
    var x = UnpackJson<Foo[]>(blob);
    public class Foo
    {
        public string ID;
        public Bar SubItem;
    }
    public class Bar
    {
        public int Topic_ID;
        public int Subject_ID;
        public string subject; 
    }
