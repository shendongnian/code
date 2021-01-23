    public class GenericTest<T> where T : class   
    {
        static int genericIntField { get; set; }
    
        public GenericTest(int setGenericIntField)
        {
            genericIntField = setGenericIntField;
        }
    
        public int GetStaticFieldValue()
        {
            return genericIntField;
        }
    }
