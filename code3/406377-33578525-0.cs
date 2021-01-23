    public Task GetData()
    {
        using(new SqlConnection(connString))
        {
            return SomeAsyncOperation();
        }
    }
