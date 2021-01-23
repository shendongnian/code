    public class CFactory
    {
        public CFactory()
        {
            CreatedCBacking = new List<C>();
        }
    
        private List<C> CreatedCBacking;
    
        public IList<C> CreatedC
        {
            get
            {
                 return CreatedCBacking.AsReadonly();
            }
        }
    
        public C NewC(String s, string t, bool b)
        {
           C temp = new C(s, t, b);
           CreatedCBacking.Add(temp);
           return temp;
        }
    
    }
    
    public class C
    {
         public C(String s, string t, bool b)
         {
             //You class here
         }
    }
