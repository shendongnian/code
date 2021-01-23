    public partial class form1
    {
        private static readonly ISomeConstructedClass someConstructedClass;
        public form1()
        {
            Class2.SomeDependency = new SomeDependency();
            someConstructedClass = Class1.SomeConstructedClass;
            someConstructedClass.Whatever();
        }
    }
