    MyEvent += SingleUseEventHandler<SomeEventArgs>.Create(SomeHandlerMethod);
    public static class SingleUseEventHandler<TArgs>
      where TArgs : EventArgs
    {
      public static EventHandler<TArgs> Create(EventHandler<TArgs> handler)
      {
         var helper = new SingleUseEventHandler<TArgs, EventHandler<TArgs>>(handler);
         return helper.InvokeIfFirstTime;
      }
    }
