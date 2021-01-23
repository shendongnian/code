    var colorsTypeInfo = typeof(Colors).GetTypeInfo();
    var properties = colorsTypeInfo.DeclaredProperties;
    Dictionary<string, string> colours = new Dictionary<string, string>();
    foreach (var dp in properties)
    {
        colours.Add(dp.Name, dp.GetValue(typeof(Colors)).ToString());
    }
