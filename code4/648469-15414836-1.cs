    string result = string.Empty;
    try
    {
        // some code
        con.Open();
        result =  command.ExecuteScalar().ToString();        
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message);
    }
    finally
    {
        con.Close();
    }
    if (result != string.Empty)
    {
         // some code
         Response.Redirect("Default.aspx");
    }
