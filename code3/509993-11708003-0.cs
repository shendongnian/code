     public void InsertInfo()
            {
                String KKStech = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=KKSTech;Integrated Security=True";
                SqlConnection conn = new SqlConnection(KKStech);
                String insertstring = @"insert into Emp (EmpID, FirstName, LastName, MiddleName, Mob1, Mob2, Phone, Email1, Email2, EmpDesc)
                                values (@EmpID,  @FirstName, @LastName, @MiddleName, @Mob1, @Mob2)";
                SqlCommand cmd = new SqlCommand(insertstring, conn);
                cmd.CommandText = insertstring;
                cmd.CommandType = CommandType.Text;
    
                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@EmpID", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@FirstName", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@LastName", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@Mob1", TextBox5.Text);
                    cmd.Parameters.AddWithValue("@Mob2", TextBox6.Text);
                    cmd.ExecuteNonQuery();
                }
    
                finally
                {
                    conn.Close();
                }
            }
