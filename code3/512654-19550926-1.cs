    public WinRtObject()
    {
      _otherClass.Event += (sender, o) => OnChanged(o);
    }
    public event EventHandler<Object> Changed;
    private void OnChanged(object e)
    {
      EventHandler<object> handler = Changed;
      if (handler != null)
        handler(this, e);
    }
