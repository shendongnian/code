    public static void Exception()
    {
        try
        {
            foreach(var item in list)
            {
                try
                {
                    throw new Exception("What now?");
                }
                finally
                {
                    continue;
                }
            }
        }
        catch
        {
            //Do I get hit?
        }
    }
