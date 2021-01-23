        public void Load_Data()
            {
                using (SqlConnection connection = new SqlConnection(DatabaseServices.connectionString)) //use your connection string here
                {
                    var bindingSource = new BindingSource();
                    string fetachSlidesRecentSQL = "select top (50) * from dbo.slides order by created_date desc";
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(fetachSlidesRecentSQL, connection))
                    {
                        try
                        {
                           SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                            DataTable table = new DataTable();
                            dataAdapter.Fill(table);
                            bindingSource.DataSource = table;
                            recent_slides_grd_view.ReadOnly = true;
                            recent_slides_grd_view.DataSource = bindingSource;
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
