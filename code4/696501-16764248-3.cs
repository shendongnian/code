    var class1 = new Class1() { Property = "a", SubProperty = new SubClass1() { SubProperty = "b" } };
    var class2 = Convert<Class2>(class1);
    public static TTarget Convert<TTarget>(object source) where TTarget : new()
    {
        var ser = new JavaScriptSerializer();
        var json = ser.Serialize(source);
        return ser.Deserialize<TTarget>(json);
    }
.
    public class Class1
    {
        public string Property { get; set; }
        public SubClass1 SubProperty { get; set; }
    }
    public class SubClass1
    {
        public string SubProperty { get; set; }
    }
    public class Class2
    {
        public string Property { get; set; }
        public SubClass2 SubProperty { get; set; }
    }
    public class SubClass2
    {
        public string SubProperty { get; set; }
    }
