	string partNumbers = @"1017Foo
	1121BAR
	SomethingElse";
	string searchText = @"SUPERCOLA A 51661017FOOAINDO
	DASUDAMA C 89891121BARBLO5W";
	
	string[] searchTerms = partNumbers.Split('\n');
	string[] searchedLines = searchText.Split('\n');
	
	StringBuilder output = new StringBuilder();
	
	foreach(string searchTerm in searchTerms){
		int matchCount = 0;
		
		output.AppendLine(string.Format("For term: {0}", searchTerm.Trim()));
		foreach(string searchedLine in searchedLines){
			if(searchedLine.Trim().ToLower().Contains(searchTerm.Trim().ToLower())){
				output.AppendLine(searchedLine.Trim());
				matchCount++;
			}
		}
		
		if(matchCount == 0){
			output.AppendLine("There was no match");
		}
		
		output.AppendLine("== End of search ==");
	}
	
	Console.WriteLine(output.ToString());
