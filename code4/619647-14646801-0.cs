     string str = string.Empty;
     try
     {
        var sb = new StringBuilder();
       SqlConnection con = new SqlConnection();
        con.ConnectionString = connString;
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        var collection = ListLawCat.CheckedItems;
        foreach (var item in collection)
        {
          
        com.CommandText = "Insert into TABLE (COL1, COL2) values ('" +  item.Value+ "','" + DocID + "') ";
        com.CommandType = CommandType.Text;
        con.Open();
        int j = com.ExecuteNonQuery();
        if (j > 0)
        {
            Response.Write("insert successfully");
            Response.Write( item.Value);
        }
        else
        {
            Response.Write("Not Inserted");
        }
     con.Close();
        }
            
       
    }
    catch (Exception ex)
    {
        Response.Write(ex.Message);
    }
