    myTable.myColumn =" Me & You";
    
    string testString="";
    SQLConnection con = new SQLConnection(...)
    SQLCommand command=new SQLCommand("Select Top 1 * from myTable",con)
    SQLDataReader reader= command.ExecuteQuery()
    while (reader.read())
    {
        testString=reader["myColumn"].ToString().Replace("&","&&");
        MessageBox.Show(testString);
    }
