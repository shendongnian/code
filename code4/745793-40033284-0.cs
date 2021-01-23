    using (var reader = command.ExecuteReader())
    {
        var resultCount = 0;
        do
        {
            if (reader.FieldCount > 0)
                resultCount++;
    
            while (reader.Read())
            {
                // Insert logic to actually consume data here…
                // HandleRecordByResultIndex(resultCount - 1, (IDataRecord)reader);
            }
        } while (reader.NextResult());
    }
