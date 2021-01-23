    public static void AddNumber(this StringBuilder builder, string id)
    {
        var originalValue = builder.ToString();
        if (originalValue.EndsWith(",") || string.IsNullOrEmpty(originalValue))
             builder.Append(id);
        else
             builder.Append("," + id);
    }
    var testing = new StringBuilder();
    testing.AddNumber("1");
    testing.AddNumber("2");
    testing.AddNumber("3");
