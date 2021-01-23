    if (stringTablePart == null)
    {
        // Create it.
        stringTablePart = wbPart.AddNewPart<SharedStringTablePart>();
        stringTablePart.SharedStringTable = new SharedStringTable();
    }
    
    var stringTable = stringTablePart.SharedStringTable;
    //if (stringTable == null)
    //{
    //    stringTable = new SharedStringTable();
    //}
