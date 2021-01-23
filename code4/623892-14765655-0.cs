    namespace NamespaceA
    {
        public class ClassA<T1> where T1 : IOForClassA.ICanOutput
        {
            T1 mT1;
            public T1 Type1
            {
                get { return mT1; }
            }
        }
    
        public class IOForClassA
        {
            public interface ICanOutput
            {
                void OutputFunction();
            }
    
            public static void Output<T>(ClassA<T> aClassA_WithOutputCapabilities) where T : IOForClassA.ICanOutput
            {
                aClassA_WithOutputCapabilities.Type1.OutputFunction();
            }
        }
    }
    
    namespace NamespaceB
    {
        public class ClassB
        {
            public class OutputableClassA : NamespaceA.IOForClassA.ICanOutput
            {
                public void OutputFunction()
                {
                }
            }
            public ClassB()
            {
                NamespaceA.ClassA<OutputableClassA> aOutputableA = new NamespaceA.ClassA<OutputableClassA>();
                NamespaceA.IOForClassA.Output(aOutputableA);
            }
        }
    }
