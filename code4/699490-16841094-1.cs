    public class MyClass
    {
        public static MyClass Create()
        {
            var c = new MyClass();
            c.SomeProperty = "12345";
            c.OtherProperty = DateTime.Now.ToString();
            return c;
        }
    }
