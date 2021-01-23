    class SDKCommunication
    {
       public event EventHandler<CustomEventHandler1> RaiseCustomEventHandler1;
       protected virtual void OnRaiseCustomEventHandler1(CustomEventHandler1 e)
       {
          EventHandler<CustomEventHandler1> handler = RaiseCustomEventHandler1;
          if (handler != null)
          {
             handler(this,e);
          }
       }
       
       //Custom Method that is called somewhere
       internal void custommethod()
       {
          OnRaiseCustomEventHandler1(new CustomEventHandler1("johnsmith", "localhost");
       }
    }
