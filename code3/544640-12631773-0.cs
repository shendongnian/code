    var url = "myurl.com/hwid.txt";
    var client = new WebClient();
    
    using (var stream = client.OpenRead(url))
    using (var reader = new StreamReader(stream))
    {
    	string downloadedString;
    	while ((downloadedString = reader.ReadLine()) != null)
    	{
    		if (downloadedString == finalHWID)
    		{
    			update();
    			allowedIn = true;
    			break;
    		}
    	}
    }
    
    if (allowedIn == false)
    {
    	MessageBox.Show("You are not allowed into the program!", name, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
