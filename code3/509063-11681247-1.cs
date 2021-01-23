    public static TResult SafeInvoke(this T isi, Func call) where T : ISynchronizeInvoke
    {
        if (isi.InvokeRequired) {
            IAsyncResult result = isi.BeginInvoke(call, new object[] { isi });
            object endResult = isi.EndInvoke(result); return (TResult)endResult;
        }
        else
            return call(isi);
    }
    
    public static void SafeInvoke(this T isi, Action call) where T : ISynchronizeInvoke
    {
        if (isi.InvokeRequired) isi.BeginInvoke(call, new object[] { isi });
        else
            call(isi);
    }
