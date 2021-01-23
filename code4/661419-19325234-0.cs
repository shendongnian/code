    List<T> onlyNonBlankRows = _queryFactory.Worksheet<T>(firstWorksheetWithColumnHeaders)
        // calling ToList here is workaround to avoid Remotion.Data.Linq.Parsing.ParserException for Select((item,index) => ...) - "This overload of the method 'System.Linq.Queryable.Select' is currently not supported, but you can register your own parser if needed."
        .ToList()
        .Select((typedRow, index) => new { typedRow, index })
        // Join the worksheet to an untyped projection of the same worksheet so that we can find totally blank rows
        .Join(
            _queryFactory.Worksheet(firstWorksheetWithColumnHeaders)
        // calling ToList here is workaround to avoid Remotion.Data.Linq.Parsing.ParserException for Select((item,index) => ...)
                        .ToList()
                        .Select(
                            (untypedRow, indexForUntypedRow) =>
                            new { untypedRow, indexForUntypedRow }),
        // join on row index - row 1 matches row 1 etc
            arg => arg.index, arg => arg.indexForUntypedRow,
            (a, b) => new { a.index, a.typedRow, b.untypedRow })
        // Exclude rows where all cells are empty 
        .Where(x => x.untypedRow.Any(cell => cell.Value != DBNull.Value))
        .Select(joined => joined.typedRow).ToList();
