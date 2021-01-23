    private Client _client = new Client();
    
    public void Foo()
    {
    	// Since _client is declared in the outer scope now, the data we assign to _client.Username
    	// below will still be there even when Foo() finished execution.
     	_client.Username = "SomeUser";
    } 
    
    public void Bar()
    {
    	// This'll still give us "SomeUser", since the object is still "alive" since we've called Foo().
    	Console.WriteLine("Username: " + _client.Username);
    }
