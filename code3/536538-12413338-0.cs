    var tables = doc.Descendants("Table")
                    .ToDictionary(t => (string) t.Attribute("name"),
                                  t => ExtractRowsFromTable(t));
    ...
    private static List<Dictionary<string, string>> ExtractRowsFromTable(XElement table)
    {
        return table.Elements("Row")
                    .Select(row => row.Elements("Column")
                                      .ToDictionary(c => (string) c.Attribute("name"),
                                                    c => (string) c.Attribute("value"))
                    .ToList();
    }
