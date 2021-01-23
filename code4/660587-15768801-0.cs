    var list = new List<ValidationResult>();
    foreach (Thing t in someCollection)
    {
        t.ValidationResults = t.Validate();
        list.AddRange(t.ValidationResults);
    }
    ViewBag.ValidationResults = list;
