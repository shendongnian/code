    var foo = new Foo()
    {
        PropertyA   = "ABC",
        PropertyB   = 123,
    
        PropertyC   = new Foo()
        {
            PropertyA   = "DEF",
            PropertyB   = 456
        }
    };
    
    var transaction = Transaction.From<Foo>(foo, "ComeForth");
    
    Guid pendingTransactionId = Guid.Empty;
    
    // Initiate a transaction
    using(var client = new HttpClient())
    {
        client.BaseAddress  = new Uri("http://localhost:12775/api/", UriKind.Absolute);
    
        using (var response = client.PostAsJsonAsync<Transaction>("transactions", transaction).Result)
        {
            response.EnsureSuccessStatusCode();
    
            pendingTransactionId = response.Content.ReadAsAsync<Transaction>().Result.Id;
        }
    }
    
    // Retrieve status of transaction
    Transaction pendingTransaction = null;
    
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:12775/api/", UriKind.Absolute);
    
        var requestUri = String.Format(null, "transactions\\{0}", pendingTransactionId.ToString());
    
        using (var response = client.GetAsync(requestUri).Result)
        {
            response.EnsureSuccessStatusCode();
    
            pendingTransaction = response.Content.ReadAsAsync<Transaction>().Result;
        }
    }
    
    // Check if transaction has completed
    if(pendingTransaction.IsComplete)
    {
                    
    }
