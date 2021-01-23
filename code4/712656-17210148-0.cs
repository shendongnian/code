	var lines = File.ReadAllLines(path).OfType<string>().ToList();
	List<List<string>> groups = new List<List<string>>();
	List<string> current;
	foreach(var line in lines){
		if (line.Contains("Processname:;ABC Buying")){
			current = new List<string>();
			groups.Add(current)
		}
		else if (current != null) {
			current.Add(line);
		}
	}
	
