    var query = bookmarkCollection.AsEnumerable()
    .WithNext()
    .Select(pair => new Statement(){
        Title= pair.Item1.Title,
        PageNumber = pair.Item1.PageNumber,
        NextPageNumber = pair.Item2.PageNumber - 1, //note you'll need to null check for the last item
    });
