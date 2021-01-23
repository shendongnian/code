    // using System.Data.Odbc;
    string strConn = @"Driver={Microsoft Text Driver (*.txt; *.csv)};" +
        "Dbq=C:;Extensions=csv,txt";
    OdbcConnection objCSV = new OdbcConnection(strConn);
    objCSV.Open();
    OdbcCommand oCmd = new OdbcCommand("select column1,column2 " +
        "from THECSVFILE.CSV", objCSV);
    OdbcDataReader oDR = oCmd.ExecuteReader();
    while (oDR.Read())
    {
        // Do something
    }
