    SqlCeConnection conn = null;
                    SqlCeCommand com = null;
                    try
                    {
                        //SQL connection and data read begins
    
                        conn = new SqlCeConnection();
                        conn.ConnectionString = connecion; //connection is a string variable which has the connection string details
                        conn.Open();
                        com = new SqlCeCommand();
                        com.Connection = conn;
                        com.CommandType = CommandType.Text;
                        com.CommandText = "SELECT pname, cname, budget, advance, ddate FROM data WHERE (ID = @id)";
                        com.Parameters.Add("@ID", SqlDbType.Int);
                        com.Prepare();
                        MessageBox.Show("The value of count just before the loop is " + count.ToString());
    
                        for (int i = 3; i <= count; i++)
                        {
                            com.Parameters[0].Value = i;
                            using (SqlCeDataReader rd = com.ExecuteReader())
                            if (rd.Read())
                            {
                                pname = (rd["pname"].ToString());
                                cname = (rd["cname"].ToString());
                                budget = (rd["budget"].ToString());
                                advance = (rd["advance"].ToString());
                                ddate = (rd["ddate"].ToString());
    
                                TextBox tobj = new TextBox();
                                tobj.Location = new Point(10, (40 + ((i - 2) * 20)));
                                tobj.Tag = 1;
                                tobj.Text = pname;
                                tobj.AutoSize = false;
                                tobj.Width = 150;
                                tobj.ReadOnly = true;
                                this.Controls.Add(tobj);
    
                                TextBox tobj1 = new TextBox();
                                tobj1.Location = new Point(160, (40 + ((i - 2) * 20)));
                                tobj1.Tag = 2;
                                tobj1.Text = cname;
                                tobj1.AutoSize = false;
                                tobj1.Width = 150;
                                tobj1.ReadOnly = true;
                                this.Controls.Add(tobj1);
    
                                TextBox tobj2 = new TextBox();
                                tobj2.Location = new Point(310, (40 + ((i - 2) * 20)));
                                tobj2.Tag = 3;
                                tobj2.Text = budget;
                                tobj2.AutoSize = false;
                                tobj2.Width = 100;
                                tobj2.ReadOnly = true;
                                this.Controls.Add(tobj2);
    
                                TextBox tobj3 = new TextBox();
                                tobj3.Location = new Point(410, (40 + ((i - 2) * 20)));
                                tobj3.Tag = 4;
                                tobj3.Text = advance;
                                tobj3.AutoSize = false;
                                tobj3.Width = 100;
                                tobj3.ReadOnly = true;
                                this.Controls.Add(tobj3);
    
                                TextBox tobj4 = new TextBox();
                                tobj4.Location = new Point(510, (40 + ((i - 2) * 20)));
                                tobj4.Tag = 5;
                                tobj4.Text = ddate;
                                tobj4.AutoSize = false;
                                tobj4.Width = 100;
                                tobj4.ReadOnly = true;
                                this.Controls.Add(tobj4);
    
                            }
                        }
    
                        
                       
                        //SQL operation ends
                    }
                    finally
                    {
                        if (null != com) com.Dispose();
                        if (null != conn) conn.Dispose();
                    }
                }
