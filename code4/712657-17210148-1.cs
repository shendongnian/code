	var lines = File.ReadLines(path);
	List<List<string>> groups = new List<List<string>>();
	List<string> current = null;
	foreach(var line in lines){
		if (line.Contains("Processname:;ABC Buying")){
			current = new List<string>();
			groups.Add(current);
		}
		else if (current != null) {
			current.Add(line);
		}
	}
	
