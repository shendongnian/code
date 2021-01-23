    try
    {
        var client = new TestWcfServiceProxy();
        var response = client.CallTest("foo");
        client.Close();
        // process the response
    }
    catch (CommunicationException e)
    {
        ...
        client.Abort();
    }
    catch (TimeoutException e)
    {
        ...
        client.Abort();
    }
    catch (Exception e)
    {
        ...
        client.Abort();
        throw;
    }
