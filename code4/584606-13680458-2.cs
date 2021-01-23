	public bool ExploreFile(string filePath) {
		if (!System.IO.File.Exists(filePath)) {
			return false;
		}
		//Clean up file path so it can be navigated OK
		filePath = System.IO.Path.GetFullPath(filePath);
	    System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
	    return true;
	}
