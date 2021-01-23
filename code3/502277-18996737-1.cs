    QueryResult res;
    res = svc.Query("tableid", 1); // Execute query number 1
    res = svc.Query("tableid", "{{140.EX.'1'}}") // execute QB query text
    foreach (QueryRow row in result.Rows) {
        // Do something with row, use get<type>, not all shown here.
        // row.GetBool(1);
        // row.GetInt(1);
        // row.GetLong(1);
        // row.GetFloat(1);
        // row.GetDouble(1);
        // row.GetDecimal(1);
        // row.GetString(1);
        // row.GetDate(1);
        // row.GetDateTime(1);
        // row.GetObject(1);
    }
