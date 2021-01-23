    Dictionary<string, List<string>> dict = new Dictionary<string,List<string>>();
    while (dbReader.Read())
    {
        string code = (string)dbReader["CODE"];
        string subject = (string)dbReader["SUBJECT"];
        List<string> codes;
        if (dict.TryGetValue(subject, out codes))
        {
            codes.Add(code);
        }
        else
        {
            codes = new List<string>() { code };
            dict.Add(subject, codes);
        }
    }
