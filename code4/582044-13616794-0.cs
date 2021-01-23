	var lines = File.ReadAllLines(@"C:\path\ajand.txt");
	foreach (var line in lines) {
		var index = line.Trim().IndexOf(" ");
		if (index == -1) {
			continue;
		}
		
		DateTime key;
		if (DateTime.TryParseExact(line.Substring(0, index), out key)) {
			hT[key] = line.Substring(index);
		}
	}
		
