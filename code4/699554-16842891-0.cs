	var articleDictionary = 
	    context.TrackingInformations.GroupBy(x => x.ArticleId)
								    .Select(grp => new{grp.Key, Count = grp.Count()})
								    .ToDictionary(info => "ArticleId:" + info.Key, 
                                                  info => info.Count);
								
	foreach (var missingArticleId in cleanArticlesIds)
	{
		if(!articleDictionary.ContainsKey(missingArticleId))
			articleDictionary.add(missingArticleId, 0);
	}
