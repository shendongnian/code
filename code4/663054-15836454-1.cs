    var allElements = sheet
        .Rows()
        .SkipColumnHeaders()
        .ToRowLookup()
        .ToCellLookup()
        .SkipEmptyRows()
        .ToElements(strings) 
        .ToList();
    var goodElements = allElements.Where(el => el.FormatId != 0)
                                  .OrderByCompositeKey();
    var badElements = allElements.Where(el => el.FormatId == 0);
