	var fileLines = File.ReadAllLines("test.txt");
	HashSet<string> fileItems = new HashSet<string>(fileLines);
	List<string> duplicateListboxItems = listBox1.Items.Cast<string>().GroupBy(l => l).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
	if (duplicateListboxItems.Count > 0)
	{
		MessageBox.Show("The listbox contains duplicate entries.");
		return;
	}
	bool duplicateFound = false;
	List<string> outputItems = new List<string>();
	foreach (string item in listBox1.Items)
	{
		if (fileItems.Contains(item))
		{
			MessageBox.Show(String.Format("The file has a duplicate: {0}", item));
			duplicateFound = true;
			break;
		}
		outputItems.Add(item);
	}
	if (duplicateFound)
		return;
	using (StreamWriter writer = new StreamWriter("test.txt", true))
	{
		foreach (string s in outputItems)
			writer.WriteLine(s);
	}
