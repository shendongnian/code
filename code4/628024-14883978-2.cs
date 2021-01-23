    void Main()
    {
        var serial = "some serial";
        var task =  Task.Factory
            .StartNew(() => DoPrintConfigPage(serial))
            .ContinueWith(tsk =>
            {
                 if(tsk.IsFaulted)
                {
                    MessageBox.Show("something broke");
                    var flattened = tsk.Exception.Flatten();
                    flattened.Handle(ex => { MessageBox.Show("Error:" + ex.Message); return true;});
                }            
            },TaskContinuationOptions.OnlyOnFaulted);
                                   
    }
    
    public void DoPrintConfigPage(string serial)
    {
        throw new Exception("BOOM!");
    }
