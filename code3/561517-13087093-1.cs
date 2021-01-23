    public sealed class ReturnReasonList
    {
       protected List<ReturnReason> pInstance = new List<ReturnReason> {
          { .Code=1, .Description="whatever reason 1" },
          { .Code=2, .Description="whatever reason 2" },
          ... 
          { .Code=n, .Description="whatever reason n" }};
    
    
       private ReturnReasonList() {}
    
       public List<Returnreason> pInstance
       {
          get
          {
             return pInstance;
          }
       }
    }
