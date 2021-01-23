    var allElements = sheet
        .Rows()
        .SkipColumnHeaders()
        .ToRowLookup()
        .ToCellLookup()
        .SkipEmptyRows()
        .ToElements(strings) 
        .ToList();
    var goodElements = allElements.Where(x => el.FormatId != 0)
                                  .OrderByCompositeKey();
    var badElements = allElements.Where(x => el.FormatId == 0);
