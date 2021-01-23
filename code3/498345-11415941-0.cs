	class SearchResult{
		public int ID { get; set; } 
		public string Title{ get; set; }
	}
	
	void Main()
	{
	
		List<SearchResult> list = new List<SearchResult>() {
			new SearchResult(){ID=1,Title="Geo Prism 1995 GEO GEO- ABS #16213899"},
			new SearchResult(){ID=2,Title="Geo Prism 1995 GEO - ABS #16213899"},
			new SearchResult(){ID=3,Title="Geo Prism 1995 - ABS #16213899"},
			new SearchResult(){ID=3,Title="Geo Prism 1995 - ABS #16213899"},
			new SearchResult(){ID=4,Title="Wie man BBA reman erreicht"},
			new SearchResult(){ID=5,Title="Ersatz Airbags, Gurtstrammer und Auto Körper Teile "},
			new SearchResult(){ID=6,Title="JCB Excavator - ECU P/N: 728/35700"},
		};
		
		var to_search = new[] { "Geo", "JCB" };
		
        // first, get all SearchResults that contain search words.
		var result = from sr in list
					 let w = to_search.FirstOrDefault(ts => sr.Title.ToLower().Contains(ts.ToLower()))
					 where w != null
					 let a = new {sr=sr, word=w}
					 group a by a.word;
					 
        // order them by counting how often the search word is in the Title
		var matched = from g in result
					  from e in g
					  let title = e.sr.Title
					  orderby title.Select((c, i) => title.Substring(i)).Count(sub => sub.ToUpper().StartsWith(e.word))
					  select e.sr;
		
        // add the other items (those without search words in the title)
		var completeList = matched.Concat(list.Except(matched));
		
		foreach (var element in completeList)
			Debug.WriteLine(String.Format("ID={0},Title={1}", element.ID, element.Title));
	}
