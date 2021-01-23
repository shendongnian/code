    object cellFont = excelCell.GetType().InvokeMember("Font",
        BindingFlags.GetProperty, null, excelCell, null);
    Parameters = new Object[1];
    Parameters[0] = true;
    cellFont.GetType().InvokeMember("Bold",
    BindingFlags.SetProperty, null, cellFont, Parameters);
