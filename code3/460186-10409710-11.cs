    <! -- language: lang-cs -->
    
        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@myData";
        parameter.SqlDbType = System.Data.SqlDbType.Structured;
        parameter.Value = myDataTable;
        command.Parameters.Add(parameter); 
