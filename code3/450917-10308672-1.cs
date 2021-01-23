	// BE VERY CAREFUL, running this method will delete *all* the files in isolated storage... ALL OF THEM
	public static void ClearAllIsolatedStorage()
	{
		// get the handle to isolated storage
		using(IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
		{
			// Get a list of all the folders in the root directory
			Queue<String> rootFolders = new Queue<String>(file.GetDirectoryNames());
	
			// For each folder...
			while(0 != rootFolders.Count)
			{
				string folderName = rootFolders.Dequeue();
	
				// First, recursively delete all the files and folders inside the given folder.
				// This is required, because you cannot delete a non-empty directory
				DeleteFilesInFolderRecursively(file, folderName);
	
				// Now that all of it's contents have been deleted, you can delete the directory
				// itsself.
				file.DeleteDirectory(rootFolders.Dequeue());
			}
	
			// And now we delete all the files in the root directory
			Queue<String> rootFiles = new Queue<String>(file.GetFileNames());
			while(0 != rootFiles.Count)
				file.DeleteFile(rootFiles.Dequeue());
		}
	}
	
	private static void DeleteFilesInFolderRecursively(IsolatedStorageFile iso, string directory)
	{
		// get the folders that are inside this folder
		Queue<string> enclosedDirectories = new Queue<string>(iso.GetDirectoryNames(directory));
	
		// loop through all the folders inside this folder, and recurse on all of them
		while(0 != enclosedDirectories.Count)
		{
			string nextFolderPath = Path.Combine(directory, enclosedDirectories.Dequeue());
			DeleteFilesInFolderRecursively(nextFolderPath);
		}
	
		// This string will allow you to see all the files in this folder.
		string fileSearch = Path.Combine(directory, "*");
	
		// Getting the files in this folder
		Queue<string> filesInDirectory = iso.GetFileNames(fileSearch);
	
		// Finally, deleting all the files in this folder
		while(0 != filesInDirectory.Count)
		{
			iso.DeleteFile(filesInDirectory.Dequeue());
		}
	}
