    int M()
    {
        try
        {
            try
            { 
                return 123;
            }
            finally
            {
                throw new Exception();
            }
        }
        catch
        {
            return 456;
        }
    }
