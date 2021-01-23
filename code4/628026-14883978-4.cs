    void Main()
    {
        var serial = "some serial";
        var task =  Task.Factory
            .StartNew(() => DoPrintConfigPage(serial))
            .ContinueWith(tsk =>
            {
                MessageBox.Show("something broke");
                var flattened = tsk.Exception.Flatten();
                // NOTE: Don't actually handle exceptions this way, m'kay?
                flattened.Handle(ex => { MessageBox.Show("Error:" + ex.Message); return true;});
            },TaskContinuationOptions.OnlyOnFaulted);
                                   
    }
    
    public void DoPrintConfigPage(string serial)
    {
        throw new Exception("BOOM!");
    }
