    // Keep the name of the bookmark
    string bookmarkName = bookmark.Name;
    // Insert your image, as before
    InlineShape shape = bookmark.Range.InlineShapes.AddPicture(path, ref _objectMissing, ref _objectMissing, ref _objectMissing);
    // Restore the bookmark
    Object range = shape.Range;
    yourDocumentVariable.Bookmarks.Add(bookmarkName, ref range);
