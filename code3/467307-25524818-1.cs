    ThriftClient client = null;
    long ns = -1;
    try
    {
        client = ThriftClient.create("localhost", 38080);
        
		if (!client.namespace_exists("test"))
        {
			System.Console.WriteLine("Namespace test does not exist");
		    client.create_namespace("test");
        }
        ns = client.namespace_open("test");
        System.Console.WriteLine(client.hql_query(ns, "show tables").ToString());
        client.namespace_close(ns);
    } // End Try
    catch (System.Exception e)
    {
		System.Console.WriteLine (e.Message);
		System.Console.Error.WriteLine (e.StackTrace);
        
        try
        {
            if (client != null && ns != -1)
                client.namespace_close(ns);
		} 
		catch (System.Exception ex)
        {
			System.Console.WriteLine (ex.Message);
            System.Console.Error.WriteLine("Problem closing namespace \"test\" - " + e.Message);
        }
        System.Environment.Exit(1);
    } // End Catch
