            string[] Individal_Runs = Directory.GetFiles(@"D:\testfiles");
            foreach (string s in Individal_Runs)
            {
                try
                {
    String theConnString= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + s + ";Extended Properties=Excel 8.0;";
    
        OleDbConnection objConn = new OleDbConnection(theConnString);
        objConn.Open();
    
        OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [sheet1$]", objConn);
        OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
    
        objAdapter1.SelectCommand = objCmdSelect;
        DataSet objDataset1 = new DataSet();
        objAdapter1.Fill(objDataset1, "XLData");
          
         //Your code here
        
        objConn.Close();
    
                    
                }
                catch (NullReferenceException ex)
                {
                    Console.Out.WriteLine("No run");
                }
            }
