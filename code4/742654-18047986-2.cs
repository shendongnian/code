    protected void Button_Delete(object sender, EventArgs e){
     using(SqlConnection con = new SqlConnection(conn))
    {
      using(SqlCommand cmd = new SqlCommand())
    {
      cmd.Connection = con;
      cmd.CommandText = "DELETE FROM Personalinfo WHERE StudentName = '"+TextBox1.Text+"'";
      con.Open();
      cmd.ExecuteNonQuery();
      con.Close();
    }
    }
    }
