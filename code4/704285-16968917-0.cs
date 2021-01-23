    // create interface for providing {x} features
    public interface IBObj_Sf
    {
       ...
       ...
    }
    
    // create class which provides {x} features of IBObj_Sf interface
    public class BObj_Sf : IBObj_Sf
    {
       ...
       ...
    }
    
    // now implement BObj_Sub class like -
    public class BObj_Sub
    {
            // mark as readonly depending it is modifiable or 
            // not withing BObj_Sub's lifecycle
            private readonly IBObj_Sf _Sn; 
            
            public BObj_Sub(IBObj_Sf sn)
            {
                _Sn = sn;
            }
    
            public BObj_Sf Sn
            {
                get { return _Sn; }
                private set { _Sn = value; }
            }
    }
