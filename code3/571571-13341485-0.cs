      private void grabData(string filename)
                {
                        // Clear DataTaable before generating new Table Data/
                        ds.Clear();
        
                        // Connection String to the previously selected file. 
                        // HDR=Yes advises that spreadsheet has columns. 
                         
                        OleDbConnection con = new OleDbConnection(
                        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename +
                        ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"");
        
        
                        // The criteria required to Build DataTable. Select specific columns                 //from spreadsheet where teh Site Statuse is LIVE.
                        string strSQL = "SELECT * FROM [YOURTABLE]";
                        
                        // The Command that we will use with our DataAdapter.
                        OleDbCommand cmd = new OleDbCommand(strSQL, con);
        
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        da.Fill(ds, "YourTable");
        
        
                }
