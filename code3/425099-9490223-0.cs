    public class SomeClass
    {
        public static SomeClass m_instance;
    
        ...
    
        ~SomeClass()
        {
        m_instance = this;
        }
    }
