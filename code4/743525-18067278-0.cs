    try
    {
        SQLConnection con = new SQLConnection("...");
        con.Open();
        if (/*condition*/)
            throw new Exception("Exception Condition Satisfied");
    }
    catch (Exception ex)
    {
        con.Close();
        con.Dispose();
        throw ex;
    }
    return con;
