    string path = YOUR_PATH;
    foreach (string dir in System.IO.Directory.GetDirectories(path))
    {
    	if (new DirectoryInfo(dir).Name.StartsWith("."))
    	{
    		ComboBox.Items.Add(dir);
    	}
    }
