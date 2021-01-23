    var column = dt.Rows[0].ItemArray
                               .Select((r, index) => new { Value = r, Index = index })
                               .FirstOrDefault(t => DateTime.TryParse(t.ToString(),
                                                    CultureInfo.InvariantCulture,
                                                    DateTimeStyles.None,
                                                    out temp));
    if(column != null)
        Console.WriteLine(column.Index);
