    List<Doc> Documenti = new List<Doc>() {
            new Doc(""),
            new Doc("1"),
            new Doc("-4"),
            new Doc(null) };
    Documenti = Documenti.OrderBy(o => string.IsNullOrEmpty(o.Note)).ThenBy(o => 
    {
        int result;
        if (Int32.TryParse(o.Note, out result))
        {
            return result;
        } else {
            return Int32.MaxValue;
        }
    }).ToList();
    foreach (var item in Documenti)
    {
        Console.WriteLine(item.Note ?? "null");
        // Order returned: -4, 1, <empty string>, null
    }
