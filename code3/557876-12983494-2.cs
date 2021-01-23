    public class Class1
    {
      public event Action<object, EventArgs> subscribe ;
      private void raiseEvent()
      {
         var handler = subscribe ;
         if(handler!=null)
         {
            handler(this,EventArgs.Empty);//Raise the enable event.
         }
      }
    }
