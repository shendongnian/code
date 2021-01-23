    static void ProcessResult(ExpandoObject r)
    {
        string name, trimmedName = "";
        name = ((IDictionary<string, object>)r).ToList()
            .Aggregate<KeyValuePair<string, object>, string>("", (s, p) =>
            {
                return s + " " + p.Value;
            });
        trimmedName = name.Trim();
        FurtherProcess(trimmedName);
    }
    static void ProcessResult(object r)
    {
        string name, trimmedName = "";
        PropertyInfo[] ps = r.GetType().GetProperties();
        name = ps.Aggregate<PropertyInfo, string>("", (s, p) =>
        {
            return s + " " + p.GetValue(r);
        });
        FurtherProcess(trimmedName);
    }
    private static void FurtherProcess(string trimmedName)
    {
        Console.WriteLine(trimmedName);
    }
