	try
    {
		proxy.Close();
	}
    catch (Exception ex)
    {
        proxy.Abort();
    }
    finally
    {
		proxy = null;
	}
