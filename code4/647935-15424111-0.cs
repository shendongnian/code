    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            var type = myClass.GetType();
            foreach (var property in type.GetProperties())
            {
                //Get ALL custom attributes of the property
                var propattr = property.GetCustomAttributes(false);
                //Get MyAttribute Attribute of the Property
                object attr =
                    (from row in propattr
                     where row.GetType() == typeof(MyAttribute)
                     select row).FirstOrDefault();
                if (attr == null || !(attr is MyAttribute))
                    continue;
                var myAttribute = attr as MyAttribute;
                //output: NameAttrValue and AgeAttrValue 
                Console.WriteLine(myAttribute.Val);
            }
        }
    }
    public class MyClass
    {
        [My("NameAttrValue")]
        public string Name { get; set; }
        [My("AgeAttrValue")]
        public int Age { get; set; }
        public MyClass()
        {
            this.Name = "Jac";
            this.Age = 27;
        }
    }
    public class MyAttribute : Attribute
    {
        public MyAttribute(string val)
        {
            this.Val = val;
        }
        public string Val { get; set; }
    }
