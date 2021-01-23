    public static string SendData (...) {
    }
    
    public static IAsyncResult BeginSendData(..., AsyncCallback cb) {
       var f = Func<..., string>(SendData);
       return f.BeginInvoke(..., cb, f);
    }
    public static string EndSendData(IAsyncResult ar) {
       return ((Func<..., string>) ar.AsyncState).EndInvoke(ar); 
    }
