    SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Customers;", connection);
    connection.Open();
    // get the schema for the customers table
    SqlDataReader reader = command.ExecuteReader();
    DataTable schemaTable = reader.GetSchemaTable();
    // create the FileHelpers record class
    // alternatively there is a 'FixedClassBuilder'
    DelimitedClassBuilder cb = new DelimitedClassBuilder("Customers", ","); 
    cb.IgnoreFirstLines = 1; 
    cb.IgnoreEmptyLines = true; 
    // populate the fields based on the columns
    foreach (DataRow row in schemaTable.Rows)
    {
         cb.AddField(row.Field<string>("ColumnName"), row.Field<Type>("DataType")); 
         cb.LastField.TrimMode = TrimMode.Both;
    }
    // load the dynamically created class into a FileHelpers engine
    FileHelperEngine engine = new FileHelperEngine(cb.CreateRecordClass());
            
    // import your records
    DataTable dt = engine.ReadFileAsDT("testCustomers.txt"); 
