    catch (Exception e)
    {
        try
        {
            throw;
        }
        catch
        {
            Console.WriteLine("Script did not handle exception: " + e.Message);
            return null;
        }
    }
