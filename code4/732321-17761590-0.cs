    private void UpdateTable()
                {
                    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=YourDataBase;Persist Security Info=True;User ID=username;Password=pass");
                    SqlCommand cmd1 = new SqlCommand("update YourTable set amount=@kol where ID=@id", con);
                    cmd1.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd1.Parameters.AddWithValue("@kol", textBox2.Text);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                }
