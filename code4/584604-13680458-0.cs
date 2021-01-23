	//using System.Text.RegularExpressions;
	//using System.Diagonstics;
	static readonly Regex _cleanupRegex = new Regex(@"[\\/]+", RegexOptions.Compiled);
	public bool ExploreFile(string filePath) {
		if (!System.IO.File.Exists(filePath)) {
			return false;
		}
		//Clean up file path so it can be navigated OK
		filePath = _cleanupRegex.Replace(filePath, @"\");
	    Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
	    return true;
	}
