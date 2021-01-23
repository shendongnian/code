    StringBuilder builder = new StringBuilder("{ \"event\" :[");
    foreach (DataRow row in dt.Rows)
    {
        // Alternatively, use AppendFormat
        builder.Append("{\"title\" :\"");
               .Append(row[0])
               .Append("\", \"start\" : \"")
               .Append(row[1])
               .Append("\"} ,");
    }
    if (builder[builder.Length - 1] == ',')
    {
        builder.Length -= 1;
    }
    builder.Append("] }");
    string result = builder.ToString();
