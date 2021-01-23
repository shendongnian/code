    ADODB.Connection oConn = new ADODB.Connection();
    oConn.Open("Connection String", "", "", 0);
    string strQuery = "";//Your select query or the query through which you are fetching data from database";
    ADODB.Recordset rs = new ADODB.Recordset();
    System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter();
    DataTable dt = new DataTable();
    rs.Open(strQuery, " Connection String,                ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, 1);
    adapter.Fill(dt, rs);
    return dt;
