         private void button3_Click(object sender, EventArgs e)
         {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection()) // the "using" construct will close and dispose of the connection 
                {
                    dbConnection.ConnectionString = myConnectionString;
                    dbConnection.Open();
                    maskedTextBox1.Clear();
                    dateTimePicker1.Value = DateTime.Now.AddDays(0);
                    comboBox1.SelectedIndex = -1;
                    String username = comboBox2.Text;
                    using (SqlCommand command = new SqlCommand("INSERT INTO [Man Power] ([Person_Performing_Phase_2]) VALUES ([Parm1])", dbConnection))
                    {
                        command.Parameters.AddWithValue("Parm1", username);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          }
