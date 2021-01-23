    public static async Task Foo()
    {
        using (ServiceReference1.Service1Client client = new ServiceReference1.Service1Client())
        {
            Task<string> t = client.GetDataAsync(1);
            string result = await t;
        }
    }
