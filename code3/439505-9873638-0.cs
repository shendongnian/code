    private Action<int,int> myLoggingDelegate;
    private void button2_Click(object sender, EventArgs e)
    {
        myLoggingDelegate = logowanie;
        myLoggingDelegate.BeginInvoke(myParam1,myParam2,Callback,null);    //this is aynchronous
    }
    private void Callback(IAsyncResult ar)
    {
        myLoggingDelegate.EndInvoke(ar);
    }
