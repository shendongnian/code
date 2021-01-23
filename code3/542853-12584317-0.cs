    public void CallStoredProcMethod()
    {
        var task1 = System.Threading.Tasks.Task.Factory.StartNew(() => RunStoredPro());
        // thread will wait there till the operation finish
        task1.Wait();
    }
    public void RunStoredPro()
    {
        using (var connection = new SqlConnection(sqlConnString))
        {
            // your database call
        }
    }
