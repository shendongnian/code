    protected string JoinEval(string delim, param string[] fields)
    {
        var parts = new List<string>();
        foreach (string field in fields)
        {
             string value = Eval(field).ToString();
             if (!string.IsNullOrEmpty(value))
                  parts.Add(value);
        }
     
        return string.Join(delim, parts.ToArray());
    }
