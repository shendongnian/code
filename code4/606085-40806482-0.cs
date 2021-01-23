    SqlConnection SQLConn = new SqlConnection("datahere");
    SqlCommand SQLComm = new SqlCommand();
    SQLcomm.Connection = SQLConn;
    SQLConn.Open();
    SQLComm.CommandText = "SQL statement goes here"
    SqlDataReader dataReader = SQLComm.ExecuteReader();
    dataReader.Read();
    if(dataReader.HasRows == true){ //if it has rows do code
    //do code
    }
    else{
    // do other code
    }
