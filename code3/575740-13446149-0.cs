    string myColumnName = string.Empty;
    string myDataType = string.Empty;
    SqlConnection myConnection = new SqlConnection("put your database connection string here");
    myConnection.Open(); //you might have to put this inside the foreach loop
    foreach(DataGridViewColumn myColumn in dataGridView1.Columns)
    {
        myColumnName = myColumn.Name;
        myDataType = myColumn.ValueType.ToString();
    if(myDataType.Contains("int"))
    {
        myDataType = "int NULL";
    }
    if(myDataType.Contains("string"))
    {
        myDataType = "varchar(255) NULL";
    }
    SqlCommand myCommand = new SqlCommand("alter table [put your table name here] add [" + myColumnName + "] " + myDataType);
    myCommand.Connection = myConnection;
    myCommand.ExecuteNonQuery();
    }
    myConnection.Close();
