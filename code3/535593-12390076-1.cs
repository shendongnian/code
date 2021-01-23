    I have refatored your code, now it should work
    protected void Button3_Click(object sender, EventArgs e){
    SqlConnection conn = new   SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
    SqlCommand cmd = new SqlCommand("UPDATE aspnet_membership SET Email = @email WHERE UserName = @id1", conn);
    cmd.Connection = conn;
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.AddWithValue("@email", TextBox2.Text);
    cmd.Parameters.AddWithValue("@id1", TextBox3.Text);   
     try { 
    conn.Open();
    cmd.ExecuteNonQuery();
  
       }
      catch(Exception ex){ 
      throw ex;    
      }
    finally{    
    conn.Close();
       }
     }
