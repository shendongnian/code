    string newLine;
    if (line.Contains("message")) {
        newLine = String.Concat("HEJHEJ ", Environment.NewLine);
    }
    else {
        newLine = String.Concat(line, Environment.NewLine);
    }
    result.Append(newLine);
