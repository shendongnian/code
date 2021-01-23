	var fileLines = File.ReadAllLines("test.txt");
	HashSet<string> fileItems = new HashSet<string>(fileLines);
	using (StreamWriter writer = new StreamWriter("test.txt", true))
	{
		bool duplicateFound = fileItems.Any(fi => listBox1.Items.Cast<string>().Any(i => i == fi));
		if (duplicateFound)
			MessageBox.Show("Duplicate items found.");
		else
			foreach (object item in listBox1.Items)
				writer.WriteLine(item.ToString());
	}
