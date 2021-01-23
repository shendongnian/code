	var items = XDocument.Parse(data)
		.Elements("findItemsByKeywordsResponse")
		.Elements("searchResult")
		.Elements("item")
		.Select(item =>
		{
			var li = item.Element("listingInfo");
			
			return new
			{
				Title = (string)item.Element("title"),
				EndTime = li != null ? (DateTime?)li.Element("endTime") : null,
				ListingType = li != null ? (string)li.Element("listingType") : null,
			};
		});
