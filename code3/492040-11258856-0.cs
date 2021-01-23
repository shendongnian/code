    string commandText = string.Format("SELECT {0}, {1} FROM Scope() "
                                + "WHERE {0} = 'test' AND {1} BETWEEN '@minDate' "
                                + "AND '@maxDate'"
                                + " ORDER BY {1} Desc", "TestField", "DateField");
    
    SqlCommand command = new SqlCommand(commandText, connection);
    command.Parameters.Add("@minDate", SqlDbType.SqlDateTime);
    command.Parameters["@minDate"].Value = minimumDate;
    command.Parameters.Add("@maxDate", SqlDbType.SqlDateTime);
    command.Parameters["@maxDate"].Value = maximumDate;
