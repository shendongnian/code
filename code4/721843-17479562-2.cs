    var dictionaryOfNumberByName = File.ReadLines(@"c:\myFile.txt")
      .Aggregate(Tuple.Create("unknown", new Dictionary<string, List<int>>()),
       (all, line) => { 
	      int value;
	      if(!int.TryParse(line, out value))
		  {
		      all.Item2.Add(line, new List<int>());
		      return Tuple.Create(line, all.Item2); // switch current word
		  }
	      else
		  {
		    all.Item2[all.Item1].Add(value);
		    return all;
		  }
	});	
