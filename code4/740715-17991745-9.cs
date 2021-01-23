    public static void Break()
    {
        foreach(var item in list)
        {
            try
            {
                break;
            }
            finally
            {
                continue;
            }
        }
    }
