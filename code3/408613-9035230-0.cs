    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["chestionar"].ConnectionString); 
    TextBox[] rasp = new TextBox[] { textbox1, textbox2, textbox3, textbox4, textbox5 }; 
     
    foreach (TextBox raspuns in rasp) 
    { 
        SqlCommand cmd = new SqlCommand("INSERT INTO Raspunsuri Values(@raspuns,@cnp,@data,'5')", con); 
     
        cmd.Parameters.AddWithValue("@cnp", Session["sesiune_cnp"]); 
        cmd.Parameters.AddWithValue("@raspuns", raspuns.Text); 
        cmd.Parameters.AddWithValue("@data", DateTime.Now.ToLocalTime()); 
     
        try 
        { 
            con.Open(); 
            cmd.ExecuteNonQuery(); 
        } 
     
        catch (Exception ex) 
        { 
            Console.WriteLine("Error:" + ex); 
        } 
        finally 
        { 
            con.Close(); 
        } 
    }
    Response.Redirect("User6.aspx"); 
