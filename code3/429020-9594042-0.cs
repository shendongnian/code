    static bool Test()
    {
        bool returnValue;
    
        try
        {
            try
            {
                return returnValue = true;
            }
            finally
            {
                throw new Exception();
            }
        }
        catch (Exception)
        {
            Console.WriteLine("In the catch block, got {0}", returnValue);
            return false;
        }
    }
