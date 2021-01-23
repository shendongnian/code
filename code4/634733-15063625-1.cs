    using (OleDbConnection con = new OleDbConnection("YourConnectionString"))
                {
                        var adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = new OleDbCommand("SELECT * FROM [YourAccessTable]", con);
    
                        var cbr = new OleDbCommandBuilder(adapter);
    
                        cbr.GetDeleteCommand();
                        cbr.GetInsertCommand();
                        cbr.GetUpdateCommand();
    
                        try
                        {
                            con.Open();
                            adapter.Update(YourDataTable);
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
            }
