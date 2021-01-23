    string line;
    var sb = new StringBuilder();
    using (var sr = new StreamReader(stream, Encoding.UTF8))
    {
        while ((line = sr.ReadLine()) != null)
        {
            if (Regex.IsMatch(line, pattern);
                sb.Append(line);
        }
    }
    string result = sb.ToString();
