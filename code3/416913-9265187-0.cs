    private void textBox1_Leave(object sender, System.EventArgs e)
    {
      string StrSql = Textbox1.Text; // your sql queries goes here
      using(SqlConnection con = new SqlConnection(Constr))
      {
        SqlCommand cmd = new SqlCommand(strSql, con); 
        cmd.ExecuteNonQuery();  
      }
    
    }
