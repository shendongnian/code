    var bc = bookmarkCollection.AsEnumerable();
    IEnumerable<Statement> statement = bc.Zip(bc.Skip(1).Concat(new Bookmark[] { null }), 
        (b1,b2) => new Statement()
        {
            Title= b1.Title,
            PageNumber = b1.PageNumber,
            NextPageNumber = b2 == null ? 0 : b2.PageNumber - 1
        });
