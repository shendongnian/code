    private void Test(object sender)
    {
        base.Dispatcher.BeginInvoke((System.Delegate)(Action)delegate
        {
            //some code
        }, new object[0]);
    }
