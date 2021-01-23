    private void OnConnectionResumed()
    {
        Task.Factory.StartNew(() =>
            {
                var session = connection.CreateSession();
                ...
            });
    }
