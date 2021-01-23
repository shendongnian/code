    public class Service
    {
         ICallbackContract _callback
         public void Login()
         {
                 //method your connecting client calls
             _callback = OperationContext.Current.GetCallbackChannel<ICallbackContract>();
         
         }
         private void recordInserted()  //This method is called when the event is fired
         {
           
              _callback.insertsuccessful();
         }
    }
