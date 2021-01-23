    string path = YOUR_PATH;
    foreach (string dir in System.IO.Directory.GetDirectories(path))
    {
    	if (dir.StartsWith("."))
    	{
    		ComboBox.Items.Add(dir);
    	}
    }
