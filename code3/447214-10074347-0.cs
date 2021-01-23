    var replacements = ListA
        .Where(a => a.DepartmentID == null)
        .Join(ListB, 
             a => a.ID, 
             b => b.ID, 
             (a, b) => new { Source = a, Replacement = b }
        );
    foreach (var item in replacements)
    {
        // here you could perform more replacements
        item.Source.DepartmentID = item.Replacement.DepartmentID;
    }
