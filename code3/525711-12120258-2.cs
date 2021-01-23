	private bool IsImage(HttpPostedFileBase file)
	{
		if (file.ContentType.Contains("image"))
		{
			return true; 
		}
		string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" }; // add more if u like...
		
        // linq from Henrik Stenbæk
		return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
	}
