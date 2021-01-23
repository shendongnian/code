    private void ff(..parameters...);{}
    DelegateHelper2 myDelegate =  new DelegateHelper2(ff);
    // invoke asynchronyously 
    IAsyncResult result = myDelegate.BeginInvoke(..parameters..., CallBack2, myDelegate);
    
    private void CallBack2(IAsyncResult iasync)
    {
        if (iasync != null)
        {
            try
            {
                DelegateHelper2 action1 = (DelegateHelper2)iasync.AsyncState;
                action1.EndInvoke(iasync);
            }
            catch (Exception ex)
            {
                //Trace exeption somehow 
            }
        }
    }
