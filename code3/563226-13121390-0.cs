	void ReadSubDirectories(FTPConncetion connection, FTPFile[] files)
	{
		foreach (var file in files)
		{
			if (file.Dir)
			{
				// Save parent directory
				var curDir = connection.ServerDirectory;
				
				// Move into directory
				connection.ChangeWorkingDirectory(file.Name)
							
				// Read all files
				ReadSubDirectories(connection, connection.GetFileInfos());
				
				// Move back into parent directory
				connection.ChangeWorkingDirectory(curDir)
			}
			else
			{
				// Do magic with your files
			}
		}
	}
