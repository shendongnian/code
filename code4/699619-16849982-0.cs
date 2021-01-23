    DataSet ds = new DataSet();
    
    if (strFile.Trim().EndsWith(".xlsx"))
    {
       strConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", strFile);
    }
    else if (strFile.Trim().EndsWith(".xls"))
    {
        strConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", strFile);
    }
    
    OleDbConnection objXConn = new OleDbConnection(strConnectionString);
                    objXConn.Open();
                    OleDbCommand objCommand = new OleDbCommand("SELECT * FROM [" + SheetName + "$]", objXConn);
                    OleDbDataAdapter adp = new OleDbDataAdapter(objCommand);
                    adp.Fill(ds);
                    objXConn.Close();
