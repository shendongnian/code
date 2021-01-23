    private void Test(object sender)
    {
        base.Dispatcher.BeginInvoke((t) =>
        {
                       //some code
        }, new object[0]);
    }
