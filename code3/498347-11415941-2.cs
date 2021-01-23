	class SearchResult{
		public int ID { get; set; } 
		public string Title{ get; set; }
	}
	
	void Main()
	{
	
		List<SearchResult> list = new List<SearchResult>() {
			new SearchResult(){ID=4,Title="Wie man BBA reman erreicht"},
			new SearchResult(){ID=5,Title="Ersatz Airbags, Gurtstrammer und Auto Körper Teile "},
			new SearchResult(){ID=6,Title="JCB Excavator - ECU P/N: 728/35700"},
			new SearchResult(){ID=2,Title="Geo Prism 1995 GEO - ABS #16213899"},
			new SearchResult(){ID=3,Title="Geo Prism 1995 - ABS #16213899"},
			new SearchResult(){ID=1,Title="Geo Prism 1995 GEO GEO- ABS #16213899"},
		};
		
		var to_search = new[] { "Geo", "JCB" };
		
		var result = from sr in list
					 let w = to_search.FirstOrDefault(ts => sr.Title.ToLower().Contains(ts.ToLower()))
					 where w != null
					 let a = new {sr=sr, word=w.ToLower()}
					 group a by a.word into g
					 orderby g.Count() descending
					 let sorted = g.OrderByDescending(a=> a.sr.Title.Select((c, i) => a.sr.Title.Substring(i)).Count(sub => sub.ToLower().StartsWith(a.word)))
					 from a in sorted 
					 select a.sr;
					  
		var completeList = result.Concat(list.Except(result));
		
		foreach (var element in completeList)
			Debug.WriteLine(String.Format("ID={0},Title={1}", element.ID, element.Title));
	}
