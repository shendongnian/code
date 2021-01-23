    while (reader.Read())
    {
        var record = new PSObject();
        for (var i = 0; i < reader.FieldCount; i++)
        {
            record.Properties.Add(new PSVariableProperty(
                new PSVariable(reader.GetName(i), reader.GetValue(i))
                ));
        }
        WriteObject(record);
    }
