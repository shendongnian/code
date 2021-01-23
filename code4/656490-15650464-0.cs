    //Be sure to add this reference:
    //Project>Add Reference>.NET tab>Microsoft.Office.Interop.Word
    //open Word App
    Microsoft.Office.Interop.Word.Application msWord = new Microsoft.Office.Interop.Word.Application();
    //make it visible or it'll stay running in the background
    msWord.Visible = true;
    //open a new document based on the Word template.
    //You shouldn't open the template directly using msWord.Documents.Open(path) unless you want to edit the template itself.
    Microsoft.Office.Interop.Word.Document wordDoc = msWord.Documents.Add(@"c:\MyTemplate.dotx");
            
    //find the bookmark
    string bookmarkName = "BookmarkToFind";
    if (wordDoc.Bookmarks.Exists(bookmarkName))
    {
        Microsoft.Office.Interop.Word.Bookmark bk = wordDoc.Bookmarks[bookmarkName];
        //set the document's range to immediately after the bookmark.
        //If you want to add the table *into* the bookmark, it needs to be done differently.
        //This page has a good explanation of the differences between adding to the bookmark's range vs adding after the bookmark's range.
        //http://gregmaxey.mvps.org/word_tip_pages/insert_text_at_or_in_bookmark.html
        //It's a little more hassle because you have to re-add the bookmark after inserting into it,
        //so inserting after the bookmark is usually fine less you're going to be inserting text programmatically at the same bookmark a second time.
        Microsoft.Office.Interop.Word.Range rng = wordDoc.Range(bk.Range.End, bk.Range.End);
        //create a table with 8 rows and 5 columns into the range.
        Microsoft.Office.Interop.Word.Table tbl = wordDoc.Tables.Add(rng, 8, 5);
        //set the table's borders.
        tbl.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        tbl.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //merge the cells in the first row down to 2 columns (Word's cells start at 1, not at 0).
        tbl.Cell(1, 1).Merge(tbl.Cell(1, 3));
                
        //distribute the columns evenly
        tbl.Rows[1].Select();
        msWord.Selection.Cells.DistributeWidth();
        //rows 2-5 already have 5 columns so don't touch them.
        //merge rows 6-8 into single-columns rows.
        for (int x = 6; x < 9; x++)
        {
            tbl.Cell(x,1).Merge(tbl.Cell(x,5));
        }
        //put the cursor in the table's first cell.
        rng=wordDoc.Range(tbl.Cell(1,1).Range.Start, tbl.Cell(1,1).Range.Start);
        rng.Select();
