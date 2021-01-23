    var result = new { event = dt.AsEnumerable()
                                 .Select(r => new { 
                                     title = r.Field<string>(0),
                                     start = r.Field<DateTime>(1))
                                 .ToArray() };
    // Or whatever, depending on the library you use
    var json = JsonSerializer.ToJson(result);
