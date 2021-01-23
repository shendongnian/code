    var keyValLookup = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Select(l =>
        {
            var keyVal = l.Split('=');
            return new { Key = keyVal[0].Trim(), Value = keyVal.ElementAtOrDefault(1) };
        })
        .Where(x => x.Key.Length > 0)
        .ToLookup(x => x.Key, x => x.Value);
    IEnumerable<string> values = keyValLookup["MyKey3"];
    Console.Write(string.Join(", ",values)); // MyVal3, MyVal3
