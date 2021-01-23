    // Get bookmark
    var bookmark = myDocument.Bookmarks["myBookmark"];
    
    // Get the list item
    var listItem = bookmark.Range.ListParagraphs[1];
    
    // Change the text using "Shift+Enter" escaped using "\v"
    listItem.Range.Text = "Replacement Line 1\vReplacement Line 2\r";
