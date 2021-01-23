    void Main()
    {
        var a = ParentClass.Create(typeof(ClassA));
        var b = ParentClass.Create(typeof(ClassB));
        var c = ParentClass.Create(ParentClass.ClassAType);
        a.Dump();
        b.Dump();
        c.Dump();
    }
    
    
    public abstract class ParentClass
    {
        public static readonly Type ClassAType = typeof(ClassA); 
        public static readonly Type ClassBType = typeof(ClassB);
        public string SomeProp { get; set; }
        protected ParentClass() {}
    
        public static ParentClass Create(Type typeToCreate)
        {
            // validate that type is derived from ParentClass
            return (ParentClass)Activator.CreateInstance(typeToCreate);
        }
    }
    
    public class ClassA:ParentClass {
        public ClassA()
        {
            SomeProp = "ClassA~";
        }
    
    }
    public class ClassB:ParentClass
    {
        public ClassB()
        {
            SomeProp = "ClassB~";
        }
    }
