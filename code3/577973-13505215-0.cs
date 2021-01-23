    var con = new SqlCeConnection("Data Source=" + "|DataDirectory|\\Database1.sdf");
                    String str = "UPDATE employee SET Isdeleted ='1' WHERE empID= '"+ empID +"'";
                    var cmd = new SqlCeCommand(str,con);
                
                    try
                    {
                        con.Open();
                    }
                    catch (Exception a)
                    {
                        Console.WriteLine(a.ToString());
                    }
                    finally
                    {
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
