           // txtPath.Text is the path to the excel file
            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + txtPath.Text + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";
            OleDbConnection oleCon = new OleDbConnection(conString);
            OleDbCommand oleCmd = new OleDbCommand("SELECT field1, field2, field3 FROM [Sheet1$]", oleCon);
            DataTable dt = new DataTable();
            oleCon.Open(); 
            dt.Load(oleCmd.ExecuteReader());
            oleCon.Close();
