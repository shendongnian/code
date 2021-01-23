    using (OracleCommand crtCommand = new OracleCommand(myCommand, conn1))
                        {
                            using (OracleDataReader reader = crtCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (!reader.IsDBNull(0))
                                    {
                                        richTextBox1.AppendText(string.Format("{0}{1}{2}{3}", Environment.NewLine, reader[0].ToString().TrimEnd('\r', '\n', ' '),";", Environment.NewLine));
                                    }
                                }
                            }
                        }
