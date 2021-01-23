    public class ClassA
    {
        public ClassA()
        {
            Debug.WriteLine("Call A Constructor");
        }
    }
    
    public class ClassB:ClassA
    {
        public ClassB():this(aMethod())
        {
        }
    
        private ClassB(object empty):base()
        {
            Debug.WriteLine("Class B Second Constructor");
        }
    
        private static object aMethod()
        {
            Debug.WriteLine("Run me First");
            return null;
        }
    }
