    public class MyClass
    {
        public List<Products> Products { get; set; }
    }
    ...
    jss.Deserialize<MyClass>(json);
