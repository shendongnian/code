    var myConnection = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\Language_Batch1_OneClick.xls';Extended Properties=Excel 8.0;"); ;
    var myCommand = new OleDbCommand();
    var upCommand = new OleDbCommand();
    int i = 0;
    try
    {
        string sql = null;
        myConnection.Open();
        myCommand.Connection = myConnection;
        sql = "select ColumName1,ColumName1from,ColumName3  [sheet-name]";
        myCommand.CommandText = sql;
        var dataReader = myCommand.ExecuteReader();
        {
          //create your sql statement here
        }
    }
