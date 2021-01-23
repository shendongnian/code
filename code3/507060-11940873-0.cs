    protected delegate void OnUIThreadDelegate();
    protected void OnUIThread(OnUIThreadDelegate onUIThreadDelegate)
    {
        if (Deployment.Current.Dispatcher.CheckAccess())
        {
            onUIThreadDelegate();
        }
        else
        {
            Deployment.Current.Dispatcher.BeginInvoke(onUIThreadDelegate);
        }
    }
