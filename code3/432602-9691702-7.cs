    try
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["chestionar"].ConnectionString); 
        con.Open(); 
        SqlCommand cmd = new SqlCommand("UpsertRasPunsuri",con);  
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@keyID", 2); 
        cmd.Parameters.AddWithValue("@cnp", Session["sesiune_cnp"]); 
        cmd.Parameters.AddWithValue("@raspuns", textbox2.Text); 
        cmd.Parameters.AddWithValue("@data", DateTime.Now.ToLocalTime()); 
        cmd.Parameters.AddWithValue("@ip", ip); 
        cmd.Parameters.AddWithValue("@idsesiune", id_sesiune); 
        con.Open(); 
        cmd.ExecuteNonQuery(); 
        Response.Redirect("User3.aspx"); 
    } 
    
    catch (Exception ex) 
    { 
        Console.WriteLine("Error:" + ex); 
    } 
    finally 
    { 
        con.Close(); 
    } 
