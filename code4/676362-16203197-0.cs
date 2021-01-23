    string goSplitter = new string[] { "\r\nGO\r\n" };
    string[] cmdParts = script.Split(goSplitter, StringSplitOptions.RemoveEmptyEntries);
    StringCollection col = new StringCollection();
    col.AddRange(cmdParts);
    server.ConnectionContext.ExecuteNonQuery(col);
