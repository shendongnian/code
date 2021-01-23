    private void MyAsyncCallback(IAsyncResult ar)
    {
        int s;
        MethodDelegate dlgt = (MethodDelegate)ar.AsyncState;
        s = dlgt.EndInvoke(ar);
        MessageBox.Show(s.ToString());
    }
