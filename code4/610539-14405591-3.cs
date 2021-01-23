    var someNewCollection = New List(Of PODetailsListViewModel);
    foreach (var item in contactGrid)
        var model = new PODetailsListViewModel()
        {
             Id = item.Id
        };
        model.PODetail = new PODetailModel() /* replace with actual class name */
        {
            POHeaderId = item.POHeaderId
        };
        someNewCollection.Add(model);
    }
    return someNewCollection;
