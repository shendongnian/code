	var articleDictionary = 
	    context.TrackingInformations.Where(trackInfo => cleanArticlesIds.Contains(trackInfo.ArticleId))
                                    .GroupBy(trackInfo => trackInfo.ArticleId)
								    .Select(grp => new{grp.Key, Count = grp.Count()})
								    .ToDictionary(info => "ArticleId:" + info.Key, 
                                                  info => info.Count);
								
	foreach (var missingArticleId in cleanArticlesIds)
	{
		if(!articleDictionary.ContainsKey(missingArticleId))
			articleDictionary.add(missingArticleId, 0);
	}
