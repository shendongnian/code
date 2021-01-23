    public void ImportCsvFile(string filename)
    {
        FileInfo file = new FileInfo(filename);
    
        using (OleDbConnection con = 
                new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
                file.DirectoryName + "\";
                Extended Properties='text;HDR=Yes;FMT=Delimited(,)';"))
        {
            using (OleDbCommand cmd = new OleDbCommand(string.Format
                                      ("SELECT * FROM [{0}]", file.Name), con))
            {
                con.Open();
     
                // Using a DataTable to process the data
                using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                {
                    DataTable tbl = new DataTable("MyTable");
                    adp.Fill(tbl);
    
                    //foreach (DataRow row in tbl.Rows)
                    
                    //Or directly make a list
                    List<DataRow> list = dt.AsEnumerable().ToList();
                }
            }
        }
    } 
