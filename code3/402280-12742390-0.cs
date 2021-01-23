    using (SqlConnection sqlcnn = new SqlConnection("Data Source=.;Integrated Security=True"))
                {
                    SqlCommand sqlcmd = new SqlCommand("ALTER DATABASE DB_NAME SET OFFLINE WITH ROLLBACK IMMEDIATE", sqlcnn);
                    sqlcnn.Open();
                    sqlcmd.ExecuteNonQuery();
                    sqlcnn.Close();
                }
