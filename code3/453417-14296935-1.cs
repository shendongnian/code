    public class NonInheritableClass
    {
        static NonInheritableClass GetObject()
        {
            return new NonInheritableClass();
        }
        private NonInheritableClass()
        { 
        }
    }
