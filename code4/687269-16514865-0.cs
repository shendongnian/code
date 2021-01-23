    static void Main(string[] args)
    {
        MyClass obj =new MyClass();
    }
    public class MyClassBase
    {
        public MyClassBase()
        {
            bool hasAttribute = this.GetType().GetCustomAttributes(typeof(MyAttribute), false).Any(attr => attr != null);
            if (!hasAttribute)
            {
                throw new AttributeNotApplied("MyClass");
            }
        }
    }
    [MyAttribute("Hello")]
    class MyClass : MyClassBase
    {
        public MyClass()
        {
            
        }
    }
    internal class AttributeNotApplied : Exception
    {
        public AttributeNotApplied(string message) : base(message)
        {
            
        }
    }
    internal class MyAttribute : Attribute
    {
        public MyAttribute(string msg)
        {
            //
        }
    }
