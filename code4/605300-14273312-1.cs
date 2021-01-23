    var myConnection = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\Language_Batch1_OneClick.xls';Extended Properties=Excel 8.0;"); ;
    var myCommand = new OleDbCommand();
    var upCommand = new OleDbCommand();
    int i = 0;
    try
    {
        string sql = null;
        string Value1 =null;
        string Value2=null;
        string Value3=null;
        myConnection.Open();
        myCommand.Connection = myConnection;
        sql = "select ColumName1,ColumName1from,ColumName3  [sheet-name]";
        myCommand.CommandText = sql;
        var dataReader = myCommand.ExecuteReader();
        {
          value1=dataReader["ColumName1"].ToString();
          value2=dataReader["ColumName2"].ToString();
          value3=dataReader["ColumName3"].ToString();
        }
        string newQuery="INSERT [dbo].[TableName] ([ColumName1], [ColumName2], [ColumName3]) VALUES ('"+Value1+"', '"+Value2+"', '"+Value3+"')"
    }
