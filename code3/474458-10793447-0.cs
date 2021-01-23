    class CBRegistrar
    {
        public delegate void ActionRequiredEventHandler(object sender, ISomeClass e); 
        
        public event ActionRequiredEventHandler ActionRequired;
        void RaiseActionRequiredEvent(ISomeClass parm)
        {
           if ( ActionRequired != null)
           {
               ActionRequired(this, parm);
           }
        }
    
    }
    class APIConsumer
    {
         var callbackRegistrar = new CBRegistrar();
         public APIConsumer()
         {
                   callbackRegistrar.ActionRequired += SomeFunc;
                   
         }
         public void SomeFunc(object sender, ISomeClass data)
         {
         }
      
    }
