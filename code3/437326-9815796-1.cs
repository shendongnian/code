    sSql = "INSERT INTO [camss].[dbo].[tb_ds0402req] ( [ds0402_key] ,[lname] ) " +
           "VALUES (@DS0402Key, @VisitorLName)";
    try
    { 
        using (SqlCommand cmd = new SqlCommand(sSql, conn))
        {
         cmd.Parameters.AddWithValue("@DS0402Key", Session["DS0402Key"]);
         cmd.Parameters.AddWithValue("@VisitorLName", VisitorLName.Value);
         cmd.ExecuteNonQuery();
        }
    }
    catch (Exception ex)
    {
    //error handling code
    }
