    private void FillProductToModel(ItemViewModel model, News news)
    {
    var newList = list.OrderByDescending(x => x.News.Date).toList();
    var productViewModel = new NewsViewModel
    {
        Description = newList .Description,
        NewsId = newList .Id,
        Title = newList .Title,
        link = newList .Link,
        Imageurl = newList .Image,
        PubDate = newList .Date,
    };
    model.NewsList.Add(productViewModel);
   
