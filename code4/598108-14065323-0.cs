    foreach (TheMulticastDelegate multiCastDel in addition.GetInvocationList())
    {
        try
        {
            multiCastDel(20, 30);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
