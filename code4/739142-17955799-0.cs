    //Our main font
    var tableFont = FontFactory.GetFont(FontFactory.COURIER, 20);
    //Will hold the shortname from the database
    string itemShortName;
    //Will hold the long name which includes the periods
    string itemNameFull;
    //Maximum number of characters that will fit into the cell
    int maxLineLength = 23;
    //Our table
    var t = new PdfPTable(new float[] { 75, 25 });
    for (var i = 1; i < 10000; i+=100) {
        //Get our item name from "the database"
        itemShortName = "Item " + i.ToString();
        //Add dots based on the length
        itemNameFull = itemShortName + ' ' + new String('.', maxLineLength - itemShortName.Length + 1);
        //Add the two cells
        t.AddCell(new PdfPCell(new Phrase(itemNameFull, tableFont)) { Border = PdfPCell.NO_BORDER });
        t.AddCell(new PdfPCell(new Phrase(25.ToString("c"), tableFont)) { Border = PdfPCell.NO_BORDER });
    }
