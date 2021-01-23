    public class GenericTest<T> where T : class   
    {
        public static int StaticIntField { get; set; }
    
        public GenericTest(int setGenericIntField)
        {
            StaticIntField = setGenericIntField;
        }
    }
