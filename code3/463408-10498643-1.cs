        DataSet ds = new DataSet();
        OleDbCommand excelCommand = new OleDbCommand(); OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();
        string excelConnStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filelocation + "; Extended Properties =Excel 8.0;Hdr=Yes";
        OleDbConnection excelConn = new OleDbConnection(excelConnStr);
        excelConn.Open();
        DataTable dtPatterns = new DataTable(); excelCommand = new OleDbCommand("SELECT `PATTERN` as PATTERN, `PLAN` as PLAN FROM [PATTERNS$] where 1=0", excelConn);
        excelDataAdapter.SelectCommand = excelCommand;
        excelDataAdapter.Fill(dtPatterns);
        "dtPatterns.TableName = Patterns";
        ds.Tables.Add(dtPatterns);
        return ds;
    }
