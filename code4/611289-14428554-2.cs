    WorksheetFeed wsFeed = spreadsheet.Worksheets;
    WorksheetEntry worksheet = (WorksheetEntry)wsFeed.Entries[0];
    // Define the URL to request the list feed of the worksheet.
    AtomLink listFeedLink = worksheet.Links.FindService(GDataSpreadsheetsNameTable.ListRel, null);
    // Fetch the list feed of the worksheet.
    ListQuery listQuery = new ListQuery(listFeedLink.HRef.ToString());
    listQuery.SpreadsheetQuery = "id = 2";
    ListFeed listFeed = service.Query(listQuery);
    var row = (ListEntry)listFeed.Entries[0];
    foreach (ListEntry.Custom element in row.Elements)
    {
        if (element.LocalName == "val")
        {
            element.Value = "1";
        }
    }
    row.Update();
