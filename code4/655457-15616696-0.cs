    try
            {
                using (SqlConnection conn = new SqlConnection(Common.GetDBConnectionString()))
                {
                    conn.Open();
                    DateTime? Date;
                    DateTime.TryParseExact(txtdate.Text, "MM/dd/yyyy",
                               System.Globalization.CultureInfo.InvariantCulture,
                               System.Globalization.DateTimeStyles.None,
                               out Date);
                    if (Date == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                        Date = null;
                    using (SqlCommand cmd =
                                      new SqlCommand("UPDATE dbo.Tb_Patient SET Name = @Name, Age = @Age, Contact = @Contact, Date = @Date, Occupation = @Occupation, Gender = @Gender " +
                                          " WHERE Id=@SetVForText", conn))
                    {
                       
                        
                        cmd.Parameters.AddWithValue("@Id", SetVForText);
                        cmd.Parameters.AddWithValue("@Name", txtname.Text);
                        cmd.Parameters.AddWithValue("@Age", txtage.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtcontact.Text);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@Occupation", txtoccupation.Text);
                        cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem.ToString());
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show("Update successfully");
                        //rows number of record got updated
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Updation failed" + ex);
            }
