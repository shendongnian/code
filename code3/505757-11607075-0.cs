            using (SqlConnection cn = new SqlConnection(YourConnectionString))
            {
                cn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(cn))
                {
                    bulkCopy.DestinationTableName = "dbo.Student";
                    try
                    {
                        bulkCopy.ColumnMappings.Add("StudentID", "StudentID");
                        bulkCopy.ColumnMappings.Add("Name", "Name");
                        bulkCopy.ColumnMappings.Add("Address", "Address");
                        // Bulk write on the server
                        bulkCopy.WriteToServer(DtSet.Tables[0]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                
            }
