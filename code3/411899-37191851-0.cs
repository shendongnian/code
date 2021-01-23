    string curFile = @"C:\Dev\Test_data.mdf";
            if (!File.Exists(curFile))
            {
                SqlConnection connection = new SqlConnection(@"server=(localdb)\v11.0");
                using (connection)
                {
                    connection.Open();
                    string sql = string.Format(@"
                                        CREATE DATABASE
                                            [Test]
                                        ON PRIMARY (
                                           NAME=Test_data,
                                           FILENAME = '{0}\Test_data.mdf'
                                        )
                                        LOG ON (
                                            NAME=Test_log,
                                            FILENAME = '{0}\Test_log.ldf'
                                        )",
                        @"C:\Dev"
                    );
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                } 
            }
            
