    string connString = ConfigurationManager.ConnectionStrings[1].ToString();
    string query1 = @"insert into tbl_item (ItemCode,ItemName) values(@itemcode,@itemname)";
    string query2 = @"insert into tbl_image (ItemCode,ItemImage) values(@itemcode,@itemimage)";
    
    SqlConnection conn = new SqlConnection(connString);
    
    try
    {
        // Exc]ecute the first query.
        SqlCommand cmd = new SqlCommand(query1, conn);
        cmd.Parameters.Add("@itemcode", SqlDbType.Int, 10, "ItemCode").Value = "1001";   // Pass the actual Item code
        cmd.Parameters.Add("@itemname", SqlDbType.Text, 20, "ItemName").Value = "Item001"; //Pass the actual Item name
        cmd.ExecuteNonQuery();
    
    
        // Exc]ecute the second query.
        cmd = new SqlCommand(query2, conn);
        cmd.Parameters.Add("@itemcode", SqlDbType.Int, 10, "ItemCode").Value = "1001";   // Pass the actual Item code
        cmd.Parameters.Add("@itemimage", SqlDbType.Text, 20, "ItemImage").Value = "Image001";  // Pass the actual Item image
        cmd.ExecuteNonQuery();
    }
    catch (Exception e)
    {
        
    }
    finally
    {
        conn.Close();
    }
