    protected void Button_Update(object sender, EventArgs e){
     using(SqlConnection con = new SqlConnection(conn))
    {
      using(SqlCommand cmd = new SqlCommand())
    {
      cmd.Connection = con;
      cmd.CommandText = "UPDATE Personalinfo SET StudentName = @1 ... WHERE Student_Id= @N";
      cmd.Parameters.Add("@1",SqlDbType.NVarChar).Value = your_value;
      cmd.Para.....
      cmd.Parameters.Add("@N",.....).Value = your_student_id;
      con.Open();
      cmd.ExecuteNonQuery();
      con.Close();
    }
    }
    }
