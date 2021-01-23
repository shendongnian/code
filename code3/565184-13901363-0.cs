    object endOfDoc = "\\endofdoc";
    object missing = System.Reflection.Missing.Value;
    string totRows = 2;
    string totColumns = 2;
    
    word.Range wrdRng = doc.Bookmarks.get_Item(ref endOfDoc).Range;
    oTable = doc.Tables.Add(wrdRng, totRows, totColumns, ref missing, ref missing);
