    var batchSql = "select * from Repository; select * from StaffMembersRepository; select * from CategoriesRepository";
    // ...
    // iterate over batch results
    using(var reader = command.ExecuteReader())
    {
        var currentResultSet = 0;
        while(reader.NextResult())
        {
            currentResultSet++;
            switch(currentResultSet)
            {
                case 1:
                    while(reader.Read())
                    {
                        // retrieve row data
                    }
                case 2:
                    // similar
                case 3:
                    // similar
            }
        }
    }
