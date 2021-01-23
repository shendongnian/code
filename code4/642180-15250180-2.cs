    static BasicClass()
    {
        using (SomeConnection con = Provider.OpenConnection())
        {
            try
            {
                // Some code here
            }
            catch
            {
                // Handling expeptions, setting default value
                i = 10;
            }
        }
    }
