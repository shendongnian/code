    private static bool IsExcelXmlFileFormat(string fileName)
    {
      return fileName.EndsWith("xlsx", StringComparison.OrdinalIgnoreCase);
    }
    private void button1_Click(object sender, EventArgs e)
    {
      // Open your FileOpenDialog and let the user select a file...
      string fileName = "c:\\temp\\myexcelfile.xlsx";      
      OleDbConnectionStringBuilder connStringBuilder =
        new OleDbConnectionStringBuilder();
      connStringBuilder.DataSource = fileName;
      if (IsExcelXmlFileFormat(fileName))
      {
        // Set HDR=Yes if first row contains column titles.        
        connStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
        connStringBuilder.Add("Extended Properties", "Excel 8.0;HDR=NO;");        
      }
      else
      {
        connStringBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
        connStringBuilder.Add("Extended Properties", "Excel 8.0;");        
      }
      
      DataSet data = new DataSet();
      using (OleDbConnection dbConn = new OleDbConnection(connStringBuilder.ConnectionString))
      {
        dbConn.Open();
        
        DataTable sheets = dbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);                
        using (OleDbCommand selectCmd = new OleDbCommand(
          String.Format("SELECT * FROM [{0}]", sheets.Rows[0]["TABLE_NAME"]), dbConn))
        {
          using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter())
          {
            dbAdapter.SelectCommand = selectCmd;           
            dbAdapter.Fill(data, "mytable");                       
          }
        }
      }
      // To enumerate all rows use the following code.
      // foreach (DataRow row in data.Tables["mytable"].Rows)
      // {
      //   Console.Out.WriteLine(row[0]);
      // }
      // Display the values of column 0 in a listbox called listBox1.
      listBox1.ValueMember = data.Tables["mytable"].Columns[0].ColumnName;
      listBox1.DisplayMember = data.Tables["mytable"].Columns[0].ColumnName;
      listBox1.DataSource = data.Tables["mytable"];             
    }
