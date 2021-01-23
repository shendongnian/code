    public void Load_Data()
            {
                using (SqlConnection connection = new SqlConnection(DatabaseServices.connectionString)) 
               // replace Databaseservices with you connectionString of your own database 
                {
                var dataAdapter = new SqlDataAdapter();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        string fetachSlidesRecent = "select top (50) * from dbo.slides order by created_date desc" ;
                        command.CommandType = CommandType.Text;
                        command.CommandText = fetachSlidesRecent;
                        try
                        {
                            if (connection.State == ConnectionState.Closed)
                            {
                                connection.Open();
                            }
                            int recordsAffected = command.ExecuteNonQuery();
                        var dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);
                        recent_slides_grd_view.ReadOnly = true;
                        recent_slides_grd_view.DataSource = dataSet;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "ERROR Loading");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
