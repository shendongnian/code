    List<string> terms = new List<string> { "Summer", "Spring", "Winter" };
    var enumNames = Enum.GetNames(typeof(Term))
                        .OrderBy(s=>Enum.Parse(typeof(Term),s))
                        .ToList();
    var orderedList = terms.OrderBy(s => enumNames.IndexOf(s)).ToList();
