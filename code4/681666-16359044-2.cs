    while (reader.Read())
    {
        var callHour = new CallHour(
            DateTime.ParseExact("yyyy-mm-dd", reader.GetString(0)),
            reader.GetInt32(2),
            reader.GetInt32(3),
            reader.IsDBNull(1) ? null : reader.GetInt32(1));
        callHours.Add(callHour.Time, callHour);
    }
