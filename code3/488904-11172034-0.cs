    StringBuilder builder = new StringBuilder("{ \"event\" :[");
    foreach (DataRow row in dt.Rows)
    {
        builder.Append("{\"title\" :\"");
               .Append(dr[0])
               .Append("\", \"start\" : \"")
               .Append(dr[1])
               .Append("\"} ,");
    }
    if (builder.EndsWith(","))
    {
        builder.Length -= 1;
    }
    builder.Append("] }");
    string result = builder.ToString();
