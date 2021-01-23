    void Main()
    {
	    using (var client = new Renci.SshNet.SftpClient("sftp.host.com", "user", "password"))
	    {
		    var files = new List<String>();
            client.Connect();
            ListDirectory(client, ".", ref files);
    		client.Disconnect();
			files.Dump();
	    }
    }
	void ListDirectory(SftpClient client, String dirName, ref List<String> files)
	{
		foreach (var entry in client.ListDirectory(dirName))
		{
			
			if (entry.IsDirectory)
			{
				ListDirectory(client, entry.FullName, ref files);
			}
			else
			{
				files.Add(entry.FullName);
			}
		}
	}
