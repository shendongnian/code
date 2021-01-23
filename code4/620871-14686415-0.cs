    string strProvider = "Data Source=" + host + ";Database=" + dbname + ";User ID=" + user + ";Password=" + pass;
    MySqlConnection myConn = new MySqlConnection(strProvider);
    bool success = true;
    try
    {
        myConn.open();
    }
    catch (Exception e)
    {
         success = false;
    }
    return success;
