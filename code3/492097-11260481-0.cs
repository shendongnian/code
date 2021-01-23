    //Add these lines
    SqlParameter text = new SqlParameter("@name", SqlDbType.NVarChar);
    text.Direction = ParameterDirection.Output;
    cmd1.Parameters.Add(text);
    con.Open();
    DataTable dt = new DataTable();
    SqlDataAdapter da = new SqlDataAdapter(cmd1);
    da.Fill(dt);
    con.Close();
    
    //Change this line
    MessageBox.Show(text.Value); //This should display the @text variable in my proc
