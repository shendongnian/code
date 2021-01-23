    string[] lines = File.ReadAllLines("admin.txt");
    for (int i = 0; i < lines.Length; i++)
    {
        	if (lines[i].StartsWith(string.Format("#{0}: ", Server.Name.ToLower()))
        	{
	        	if (!lines[i].Split(';').Contains(Channel.Name.ToLower()))
	        		lines[i] += ";" + Channel.Name.ToLower();
	        }
        }
    File.WriteAllLines("admin.txt", lines);
