    protected void SendSMS()
    {
        loading.Visible = true;
    
        var task = Task.Factory.StartNew(()=>{//code that actually sends the required Mail}
        task.Wait();
        loading.Visible = false;
    }
