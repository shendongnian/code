    Class A
    {
       ...
    }
    
    Class B
    {
       ... 
    }
    
    enum eKnownTypes
    {
         A,
         B
    }
    
    Class Factory
    {
        /* 
             Implement Singleton here
             ....
        */
        public object CreateInstance(eKnownTypes t)
        {
             /*
                   Raise any event needed here
                   ...
             */
             switch (t):
             {
                  case eKnownTypes.A: return new A(); break;
                  case eKnownTypes.B: return new B(); break;
             }          
             return null;
        }
        
    }
    
    /* 
             Set Event Handlers here
             Factory.Instance.CustomEvent += new EventHandler ... 
             ....
    */
    A objectA = Factory.Instance.CreateInstance(eKnownTypes.A) as A;
    ...
