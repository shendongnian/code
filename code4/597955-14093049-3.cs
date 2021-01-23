    public class RetValDynamicVisitor
    {
        public const int FooVal = 1;
        public const int BarVal = 2;
        public T Visit<T>(T inputObj) where T : class
        {            
            // Force dynamic type of inputObj
            dynamic @dynamic = inputObj; 
            // SetRetVal is now bound at runtime, not at compile time
            return SetRetVal(@dynamic);
        }
        private FooBase SetRetVal(FooBase fooBase)
        {
            fooBase.RetVal = FooVal;
            return fooBase;
        }
        private Bar SetRetVal(Bar bar)
        {
            bar.RetVal = BarVal;
            return bar;
        }
    }
