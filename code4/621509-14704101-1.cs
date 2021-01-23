	public string Save(Group g) {
		string[] arr=g.ToArray(); // <---- :(
		System.IO.File.WriteAllLines(Path, arr); // <---- :(
		// notice: you did not show what to return in original code
	}
 
