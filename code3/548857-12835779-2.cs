    // collect the queries
    var topArticles = new List<IEnumerable<ChannelDto.ArticleDto>>(channels.Count);
    foreach(var channel in channels)
    {
        var query = channel.Articles = _session
            .QueryOver<Channel>()
            .Inner.JoinAlias(x => x.Categories, () => categoryAlias)
            .Inner.JoinAlias(x => categoryAlias.Articles, () => articleAlias)
            .Where(x => x.Id == channel.Id)
            .OrderBy(x => articleAlias.PublishDate).Desc
            .SelectList(list => list
                .Select(x => articleAlias.Name).WithAlias(() => articleDtoAlias.Name)
            )
            .TransformUsing(Transformers.AliasToBean<ChannelDto.ArticleDto>());
        topArticles.Add(query.Take(5).ToFuture());
    }
    // execute all at once (first ToList()) and collect the results
    for(int i = 0;i < topArticles.Count; i++)
    {
        channels.Articles = topArticles[i].ToList();
    }
