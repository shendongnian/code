    private string connection = @"...";
          
      protected void Button1_Click(object sender, EventArgs e)
            {
             using(SqlConnection con = new SqlConnection(connection))
        {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert INTO Personalinfo(StudentName,StudentClass,StudentRollNo)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')", con);
                    con.Open();
                   
                    cmd.ExecuteNonQuery();
                    Label4.Text = "Data Is Stored";
                }
                catch (Exception ex)
                {
                    Label4.Text = ex.Message;
                }
            }
            }
