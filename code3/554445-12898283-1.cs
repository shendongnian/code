    private void Test(object sender)
    {
        base.Dispatcher.BeginInvoke((Action)delegate
        {
            //some code
        }, new object[0]);
    }
