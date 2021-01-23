    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        var adaptor = new OleDbDataAdapter();
                        adaptor.SelectCommand = new OleDbCommand(""SELECT * FROM [StopMaster]", con);
    
                    var cbr = new OleDbCommandBuilder(adaptor);
    
                    cbr.GetDeleteCommand();
                    cbr.GetInsertCommand();
                    cbr.GetUpdateCommand();
    
                    try
                    {
                        con.Open();
                        adaptor.Update(dt);
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.Message, "OledbException Error");
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message, "Exception Error");
                    }
                }
