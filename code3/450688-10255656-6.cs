    string tableName = ddl.SelectedValue;
    string connectionString = ConfigurationManager
        .ConnectionStrings["MyConnectionString"].ConnectionString;
    string select = "SELECT * FROM [" + tableName + "]";
    SqlDataAdapter sda = new SqlDataAdapter(select, connection);
    SqlCommandBuilder scb = new SqlCommandBuilder(sda);
    sqlDS.SelectCommand = select;
    sqlDS.InsertCommand = scb.GetInsertCommand(true).CommandText;
    sqlDS.UpdateCommand = scb.GetUpdateCommand(true).CommandText;
    sqlDS.DeleteCommand = scb.GetDeleteCommand(true).CommandText;
