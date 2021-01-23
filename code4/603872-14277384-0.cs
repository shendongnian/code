     public void UpdateDatabase(DataSet data, string custID)
            {
                DataTable fromdatabase = new DataTable();
                DataTable fromFile = data.Tables[0];
    			
                string connectionString = ConfigurationManager.ConnectionStrings["TestDbOnBrie"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string sqlCmd = "SELECT * FROM dbo.TransportSchedule_Customer WHERE CustID = '" + custID + "';";
                        SqlCommand command = new SqlCommand(sqlCmd, connection);
                        using (SqlCommand updateCmd = new SqlCommand("UPDATE dbo.TransportSchedule_Customer SET DeliveryDays1=@DeliveryDays1, DeliveryHours1=@DeliveryHours1, DeliveryType1=@DeliveryType1, DeliveryDays2=@DeliveryDays2, DeliveryHours2=@DeliveryHours2, DeliveryType2=@DeliveryType2, DeliveryDays3=@DeliveryDays3, DeliveryHours3=@DeliveryHours3, DeliveryType3=@DeliveryType3,  DistanceToDealer=@DistanceToDealer WHERE Alias=@Alias AND CustID=@CustID", connection))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.UpdateCommand = updateCmd;
                                adapter.Fill(fromdatabase);
                                updateCmd.Parameters.Add("@CustID", SqlDbType.VarChar, 50, "CustID");
                                updateCmd.Parameters.Add("@Alias", SqlDbType.VarChar, 50, "Alias");
    
                                updateCmd.Parameters.Add("@DeliveryDays1", SqlDbType.VarChar, 50, "DeliveryDays1");
                                updateCmd.Parameters.Add("@DeliveryHours1", SqlDbType.VarChar, 50, "DeliveryHours1");
                                updateCmd.Parameters.Add("@DeliveryType1", SqlDbType.VarChar, 50, "DeliveryType1");
    
                                updateCmd.Parameters.Add("@DeliveryDays2", SqlDbType.VarChar, 50, "DeliveryDays2");
                                updateCmd.Parameters.Add("@DeliveryHours2", SqlDbType.VarChar, 50, "DeliveryHours2");
                                updateCmd.Parameters.Add("@DeliveryType2", SqlDbType.VarChar, 50, "DeliveryType2");
    
                                updateCmd.Parameters.Add("@DeliveryDays3", SqlDbType.VarChar, 50, "DeliveryDays3");
                                updateCmd.Parameters.Add("@DeliveryHours3", SqlDbType.VarChar, 50, "DeliveryHours3");
                                updateCmd.Parameters.Add("@DeliveryType3", SqlDbType.VarChar, 50, "DeliveryType3");
    
                                updateCmd.Parameters.Add("@DistanceToDealer", SqlDbType.VarChar, 50, "DistanceToDealer");
    
                                for (int i = 0; i < fromdatabase.Rows.Count; i++)
                                {
                                    int Resultcompare = 0;
                                    Resultcompare += string.Compare(fromdatabase.Rows[i]["DeliveryDays1"].ToString(), fromFile.Rows[i]["DeliveryDays1"].ToString());
                                    Resultcompare += string.Compare(fromdatabase.Rows[i]["DeliveryHours1"].ToString(), fromFile.Rows[i]["DeliveryHours1"].ToString());
                                    Resultcompare += string.Compare(fromdatabase.Rows[i]["DeliveryType1"].ToString(), fromFile.Rows[i]["DeliveryType1"].ToString());
    
                                    Resultcompare += string.Compare(fromdatabase.Rows[i]["DeliveryDays2"].ToString(), fromFile.Rows[i]["DeliveryDays2"].ToString());
                                    Resultcompare += string.Compare(fromdatabase.Rows[i]["DeliveryHours2"].ToString(), fromFile.Rows[i]["DeliveryHours2"].ToString());
                                    Resultcompare += string.Compare(fromdatabase.Rows[i]["DeliveryType2"].ToString(), fromFile.Rows[i]["DeliveryType2"].ToString());
    
                                    Resultcompare += string.Compare(fromdatabase.Rows[i]["DeliveryDays3"].ToString(), fromFile.Rows[i]["DeliveryDays3"].ToString());
                                    Resultcompare += string.Compare(fromdatabase.Rows[i]["DeliveryHours3"].ToString(), fromFile.Rows[i]["DeliveryHours3"].ToString());
                                    Resultcompare += string.Compare(fromdatabase.Rows[i]["DeliveryType3"].ToString(), fromFile.Rows[i]["DeliveryType3"].ToString());
    
    
                                    Resultcompare += string.Compare(fromdatabase.Rows[i]["DistanceToDealer"].ToString(), fromFile.Rows[i]["DistanceToDealer"].ToString());
                                    if (Resultcompare == 0)
                                    {
    
                                        //do nothing
                                    }
                                    else
                                    {
    
                                        fromdatabase.Rows[i]["DeliveryDays1"] = fromFile.Rows[i]["DeliveryDays1"];
                                        fromdatabase.Rows[i]["DeliveryHours1"] = fromFile.Rows[i]["DeliveryHours1"];
                                        fromdatabase.Rows[i]["DeliveryType1"] = fromFile.Rows[i]["DeliveryType1"];
    
                                        fromdatabase.Rows[i]["DeliveryDays2"] = fromFile.Rows[i]["DeliveryDays2"];
                                        fromdatabase.Rows[i]["DeliveryHours2"] = fromFile.Rows[i]["DeliveryHours2"];
                                        fromdatabase.Rows[i]["DeliveryType2"] = fromFile.Rows[i]["DeliveryType2"];
    
                                        fromdatabase.Rows[i]["DeliveryDays3"] = fromFile.Rows[i]["DeliveryDays3"];
                                        fromdatabase.Rows[i]["DeliveryHours3"] = fromFile.Rows[i]["DeliveryHours3"];
                                        fromdatabase.Rows[i]["DeliveryType3"] = fromFile.Rows[i]["DeliveryType3"];
    
                                        fromdatabase.Rows[i]["DistanceToDealer"] = fromFile.Rows[i]["DistanceToDealer"];
                                        adapter.Update(fromdatabase);
                                    }
    
                                }
    
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("ERROR in UpdateDatabase() method. Error Message : " + exception.Message);
                    }
                    finally
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
