    SqlCeConnection conn = new SqlCeConnection("Data Source = MyDatabase.sdf;");
    conn.Open();
    
    SqlCeCommand command = conn.CreateCommand();
    
    // Create and prepare a SQL statement
    //
    command.CommandText = "INSERT INTO Region (RegionID, RegionDescription) VALUES (@id, @desc)";
    
    SqlCeParameter param = null;
    
    // NOTE:
    // For optimal performance, make sure you always set the parameter
    // type and the maximum size - this is especially important for non-fixed
    // types such as NVARCHAR or NTEXT; In case of named parameters, 
    // SqlCeParameter instances do not need to be added to the collection
    // in the order specified in the query; If however you use ? as parameter
    // specifiers, then you do need to add the parameters in the correct order
    //
    param = new SqlCeParameter("@id", SqlDbType.Int);
    command.Parameters.Add(param);
    
    param = new SqlCeParameter("@desc", SqlDbType.NVarChar, 100);
    command.Parameters.Add(param);
    
    command.Parameters["@desc"].Size = 100;
