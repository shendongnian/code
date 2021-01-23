    public class PublicClass
    {
        #if DEBUG
        public class InternalClass
        #else
        private class InternalClass
        #endif
        {
            void Method() { }
        }
    }
    //Only valid when testing in Debug
    public class TestableInternalClass : PublicClass.InternalClass
    {
    
    }
