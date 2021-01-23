    ConnectionManager cm;
    System.Data.SqlClient.SqlConnection sqlConn;
    System.Data.SqlClient.SqlCommand sqlComm;
    cm = Dts.Connections["conectionManager1"];
    sqlConn = (System.Data.SqlClient.SqlConnection)cm.AcquireConnection(Dts.Transaction);
    sqlComm = new System.Data.SqlClient.SqlCommand("your SQL Command", sqlConn);
    sqlComm.ExecuteNonQuery();
    
    cm.ReleaseConnection(sqlConn);
