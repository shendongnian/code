    public string MyLongTimeToGetValueProperty
    {
         get 
         { 
              var res = DoSomeComputation();
              return res;
         }
    }
