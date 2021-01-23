    public class Test
    {
        public Test()
        {
            GetType().GetMethods()
                     .Where(x => x.GetCustomAttributes(true).OfType<MyAttribute>().Any())
                     .ToList()
                     .ForEach(x => (x.GetCustomAttributes(true).OfType<MyAttribute>().First() as MyAttribute).MyAttributeInvoke(this));
        }
        [MyAttribute]
        public void MyMethod() { }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
