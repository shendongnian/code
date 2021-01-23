    using(SqlCeConnection connection = new SqlCeConnection(.....)) 
    {
         connection.Open();
         string sqlText = "SELECT Count(*) FROM Technician WHERE Name = @name AND Password=@pwd"
         SqlCeCommand command = new SqlCeCommand(sqlText, connection);
         command.Parameters.AddWithValue("@name", txt_username.Text);
         command.Parameters.AddWithValue("@pws", txt_password.Text);
         int result = (int)command.ExecuteScalar();
                if (result > 0)
                {
                    MessageBox.Show("Login Successful");
                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(MainMenuForm));
                    t.Start();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login Unsuccessful");
                    return;
                }
                connection.Close();
            }
     }
