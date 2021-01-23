     string location=@"c:\folder\";
     string cnstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + location + ";Extended Properties=\"text;HDR=No;FMT=Delimited\";";
     string sql = "select F2,F1 from test.csv";
    
     using (OleDbDataAdapter adp = new OleDbDataAdapter(sql, cnstr))
      {
        DataTable dt = new DataTable();
        adp.Fill(dt);
    
        foreach (DataRow row in dt.Rows)
        {
           Console.WriteLine(row[0] + " " + row[1]);
        }
      }
