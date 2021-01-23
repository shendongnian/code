    public static string OxbridgeAnd(this IEnumerable<String> collection)
    {
        var output = String.Empty;
        var list = collection.ToList();
        if (list.Count > 1)
        {
            var delimited = String.Join(", ", list.Take(list.Count - 1));
            output = String.Concat(delimited, ", and ", list.LastOrDefault());
        }
        return output;
    }
