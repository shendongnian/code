    foreach(var channel in channels)
    {
        channel.Articles = _session
            .QueryOver<Channel>()
            .Inner.JoinAlias(x => x.Categories, () => categoryAlias)
            .Inner.JoinAlias(x => categoryAlias.Articles, () => articleAlias)
            .Where(x => x.Id == channel.Id)
            .OrderBy(x => articleAlias.PublishDate).Desc
            .SelectList(list => list
                .Select(x => articleAlias.Name).WithAlias(() => articleDtoAlias.Name)
            )
            .TransformUsing(Transformers.AliasToBean<ChannelDto.ArticleDto>());
    }
    // execute all subqueries at once through iterating one
    channels[0].Articles.Any();
