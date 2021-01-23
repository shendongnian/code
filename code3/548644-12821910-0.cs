    StringBuilder builder = new StringBuilder()
    
    builder.Append("Some Text Creates 1 variable");
    builder.Append("Since we havent yet created a string no 2nd variable is created");
    builder.AppendLine("Should create a return before this line");
    builder.AppendLine(Environment.NewLine);
    builder.AppendLine("Should have an empty line above it");
    return builder.ToString();
    // only creates 1 string variable
