	using System;
	using System.Collections.Generic;
	using System.IO;
	...
	List<string> list = new List<string>();
	using (StreamReader reader = new StreamReader("input.txt")) {
	  string line;
	  while ((line = reader.ReadLine()) != null) {
	    if (line.Contains(stringToSearch)) {
	      list.Add(line); // Add to list.
	    }
	  }
	}
	using (StreamWriter writer = new StreamWriter("output.txt")) {
	  foreach (string line in list) {
	    writer.WriteLine(line);
	  }
	}
