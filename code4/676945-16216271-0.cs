    var item = wsEnumerator.Current;                   
    if (item is Excel.Chart)
    {
        //Do chart operations
    }
    else if (item is Excel.Worksheet)
    {
        //Do sheetoperations
    }
