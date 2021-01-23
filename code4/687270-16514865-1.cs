    static void Main(string[] args)
    {
        MyClass obj =new MyClass();
    }
    public class MyClassBase
    {
        public MyClassBase()
        {
            bool hasAttribute = this.GetType().GetCustomAttributes(typeof(MyAttribute), false).Any(attr => attr != null);
            // as per 'leppie' suggestion you can also check for attribute in better way
            // bool hasAttribute = Attribute.IsDefined(GetType(), typeof(MyAttribute));
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
