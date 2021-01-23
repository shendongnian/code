    PageTypes type;
    //assing value to type:
    //type = ...
    var vm.Content = contentService.Get(type.getText(), vm.RowKey);
    switch (type)
    {
        case PageTypes.A:              
            return View("Article", vm);
        case PageTypes.F:
            return View("FavoritesList", vm);
    }
