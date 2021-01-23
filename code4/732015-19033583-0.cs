                  //log the Vacuum command information
                        NpgsqlEventLog.Level = LogLevel.Debug;
                        NpgsqlEventLog.LogName = VacuumLogFilePath + "rolling.log"; 
                        NpgsqlEventLog.EchoMessages = false;
                        try
                        {
                            //Run the Vacuum Command
                            NpgsqlCommand comm = new NpgsqlCommand("VACUUM VERBOSE ANALYZE", connection); 
                            comm.ExecuteNonQuery();
                           
                        }
