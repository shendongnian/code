    var keywordList = new List<string>();
    keywordList.Add("ALFA");
    keywordList.Add("145");
    var results = KeywordAdCategories.Select (kac => kac.Ad_Id).Distinct()
				.Select (a => 
					new
					{ 
						AdId=a,
						Keywords=KeywordAdCategories.Where(kac => kac.Ad_Id == a).Select(kac => kac.Keyword_Id)
					})
				.Where(ac => ac.Keywords.Intersect(Keywords.Where(kw => keywordList.Contains(kw.Name)).Select (kw => kw.Id)).Count() == keywordList.Count())
				.Select (ac => ac.AdId);
