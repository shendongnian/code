    var itemsWithoutDuration = GetAllDatesOrdered()
        .Select(d => new { TheDate = d, Enabled = GetEnabled(d) })
        .ToList();
    var items = itemsWithoutDuration
        .Select((it, k) => new { TheDate = it.d, Enabled = it.Enabled, 
             TheDuration = (k == (itemsWithoutDuration.Count - 1) ? DateTime.Now : itemsWithoutDuration[k+1].TheDate) - it.TheDate })
        .ToList();
