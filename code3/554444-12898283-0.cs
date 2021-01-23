    private void Test(object sender)
    {
                                         // VV
        base.Dispatcher.BeginInvoke(delegate()
        {
                       //some code
        }, new object[0]);
    }
