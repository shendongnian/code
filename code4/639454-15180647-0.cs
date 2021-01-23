    public delegate void InvokeDelegate();
    
    private void DoWork()
    {
        label17.BeginInvoke(new InvokeDelegate(InvokeMethod));
    }
    
    public void InvokeMethod()
    {
       label17.Text = "I execute on the UI thread!";
    }
