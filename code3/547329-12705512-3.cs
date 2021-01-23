    private void MyAsyncCallback(IAsyncResult ar)
    {
        int s;
        MethodDelegate dlgt = (MethodDelegate)((AsyncResult)ar).AsyncDelegate;
        s = dlgt.EndInvoke(ar);
        MessageBox.Show(s.ToString());
    }
