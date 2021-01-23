    public delegate void DelegateHelper2(..parameters...);
    private void ff(..parameters...);{}
    DelegateHelper2 myDelegate =  new DelegateHelper2(ff);
    // invoke asynchronyously 
    IAsyncResult result = myDelegate.BeginInvoke(..parameters..., CallBackEmpty, null);
    
    ....
    private void CallBackEmpty(IAsyncResult iasync)
    {
        if (iasync != null)
        {
            string typeName = "";
            try
            {
                System.Runtime.Remoting.Messaging.AsyncResult aresult =
                    (System.Runtime.Remoting.Messaging.AsyncResult)iasync;
                object action1 = aresult.AsyncDelegate;
                Type actionType = action1.GetType();
                typeName = actionType.ToString();
    
                if (action1 != null)
                {
                    //action1.EndInvoke(iasync);
                    actionType.InvokeMember("EndInvoke",
                        System.Reflection.BindingFlags.InvokeMethod, null,
                        action1, new object[] { iasync });
                }
            }
            catch (Exception ex)
            {
                string msg = "CallBackEmpty; for type: " + typeName +
                    " ;Exception: " + ex.ToString();
                Setup_TraceExceptions(msg);
            }
        }
    }
