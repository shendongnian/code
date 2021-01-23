    public async Task GetData()
    {
        using(new SqlConnection(connString))
        {
            await SomeAsyncOperation();
        }
    }
