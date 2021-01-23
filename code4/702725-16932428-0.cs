    public void Earning()
    {
        var data= new Bussinesslayer().Getdata();
        // Wait a minute
        Task.Delay(TimeSpan.FromMinutes(1)).Wait();
        // Re-run this method
        Task.Factory.StartNew(() => Earning());
    }
