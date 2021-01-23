        Body body = mainPart.Document.GetFirstChild<Body>();
        var paras = body.Elements<Paragraph>();
        //Iterate through the paragraphs to find the bookmarks inside
        foreach (var para in paras)
        {
            var bookMarkStarts = para.Elements<BookmarkStart>();
            var bookMarkEnds = para.Elements<BookmarkEnd>();
            
            foreach (BookmarkStart bookMarkStart in bookMarkStarts)
            {
                if (bookMarkStart.Name == bookmarkName)
                {
                    //Get the id of the bookmark start to find the bookmark end
                    var id = bookMarkStart.Id.Value;
                    var bookmarkEnd = bookMarkEnds.Where(i => i.Id.Value == id).First();
                                          
                    var runElement = new Run(new Text("Hello World!!!"));
                    para.InsertAfter(runElement, bookmarkEnd);
                                      
                }
            }
       }
       mainPart.Document.Save();
