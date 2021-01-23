    public void BLLFunction_1()
       {     
           using(TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
           {
               //do ur stuff here
               ts.Complete();
           }
       }
        public void BLLFunction_2()
       {     
           using(TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
           {
               //do ur stuff here
               ts.Complete();
           }
       }
