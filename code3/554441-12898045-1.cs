    private void Test(object sender)
    {
        base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action<object[]>)delegate(object[] s)
        {
                       //some code
        }, new object[0]);
    }
