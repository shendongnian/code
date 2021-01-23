    private void Test(object sender)
    {
        base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action<int>)delegate(int i)
        {
                       //some code
        }, 5);
    }
