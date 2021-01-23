    public void LoadInfo()
    {
        // Makes the UI show a loading indicator, blocking all actions except for CANCEL
        LoadingInfo = true;
        var service = new SomeWcfService();
        service.BeginGetInfo(CallbackMethod, service);
    }
    private void CallbackMethod(IAsyncResult ar)
    {
        // the UI is now released from loading 
        LoadingInfo = false;
        // the UI is triggered to show our data
        ViewModel.Data = (ar.AsyncState as SomeWcfService).EndGetInfo(ar);
    }
