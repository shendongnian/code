    enum Category { None, CC, CI };
    string[] tokens = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    
    List<Tuple<Category, string, DateTime>> valuesForDisplay = tokens.Aggregate(new List<Tuple<Category, string, DateTime>>(), (acc, val) => {
        if (val == "CC")
        {
            acc.Add(Tuple.Create(Category.CC, string.Empty, DateTime.MinValue));
            return acc;
        }
    
        if (val == "CI")
        {
            acc.Add(Tuple.Create(Category.CI, string.Empty, DateTime.MinValue));
            return acc;
        }
    
        DateTime dateValue;
        if (DateTime.TryParse(val, out dateValue))
        {
            acc.Last().Item3 = dateValue;
            return acc;
        }
    
        acc.Last().Item2 = val;
        return acc;
    });
