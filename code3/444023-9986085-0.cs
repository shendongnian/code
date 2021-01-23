    var list = new
    {
        firstName = "",
        lastName = "",
        position = "",
        clockInDate = DateTime.MinValue,
        clockOutDate = DateTime.MinValue
    }.CastToEnumerable(context);
    foreach (var value in list)
    { 
    }
