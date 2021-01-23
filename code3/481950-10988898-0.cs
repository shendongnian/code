    public sealed partial class C
    {
        string _t;
    
        class N
        {
            readonly C outer;
    
            public N(C parent) { outer = parent; }
    
            void m()
            {
                outer._t = "fie"; // Error is gone
            }
        }
    }
