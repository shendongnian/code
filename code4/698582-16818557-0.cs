    for (int i = 0; i < 10; i++)
    {
        try
        {
            if (i == 2 || i == 4)
            {
                throw new Exception("Test " + i);
            }
        }
        catch (Exception ex)
        {
            errorLog.AppendLine(ex.Message);
        }
    }
