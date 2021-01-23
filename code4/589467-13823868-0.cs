    public class SingleUseEventHandler<TArgs,THandler>
      where TArgs : EventArgs
    {
      public static THandler Create(EventHandler<TArgs> handler)
      {
         var helper = new SingleUseEventHandler<TArgs, THandler>(handler);
         EventHandler<TArgs> h = helper.InvokeIfFirstTime;
         return (THandler)(object)Delegate.CreateDelegate(typeof(THandler), h.Target, h.Method);
      }
      public void InvokeIfFirstTime(object sender, TArgs args)
      {
         if (!raised)
         {
            raised = true;
            handler(sender, args);
         }
      }
      public SingleUseEventHandler(EventHandler<TArgs> handler)
      {
         this.handler = handler;
      }
      bool raised;
      readonly EventHandler<TArgs> handler;
    }
