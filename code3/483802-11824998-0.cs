    UltraGridColumn fooColumn = Grid.DisplayLayout.Bands[0].Columns["Foo"];
    UltraGridColumn barColumn = Grid.DisplayLayout.Bands[0].Columns["Bar"];
    ColumnFilter fooColumnFilter = fooColumn.Band.ColumnFilters[fooColumn];
    fooColumnFilter.ClearFilterConditions();
    fooColumnFilter.FilterConditions.Add(FilterComparisionOperator.NotEquals, barColumn);
