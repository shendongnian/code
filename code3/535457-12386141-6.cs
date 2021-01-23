    var t = Assembly
        .GetAssembly(typeof(System.DateTime))
        .GetType("System.DateTimeFormat");
    var epf = t.GetMethod(
        "ExpandPredefinedFormat",
        BindingFlags.Static | BindingFlags.NonPublic);
    var pqs = t.GetMethod(
        "ParseQuoteString",
        BindingFlags.Static | BindingFlags.NonPublic);
