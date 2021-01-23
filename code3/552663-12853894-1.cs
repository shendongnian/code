    try
    {
        string selectQuery = 
            "SELECT Contact FROM dbo.Contacts WHERE dbo.Contacts.ContactID=" 
                + contactID.ToString();
        conn = new SqlConnection(CONN);
        SqlCommand cmd = new SqlCommand(selectQuery, conn);
    
        conn.Open();
        dr = cmd.ExecuteReader();
    
        dr.Read();
        context.Response.ContentType = "Application/pdf";
        context.Response.Headers.Add("Content-Disposition", 
            "attachment; filename=Contacts.pdf");
        context.Response.BinaryWrite((Byte[])dr[0]);
    }
    catch (Exception ex)
    {
        // Display friendly message
        // Log and report error
    }
    finally
    {
        dr.Close();
        conn.Dispose();
    }
