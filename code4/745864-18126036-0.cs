    BitmapImage GetImage(string sourceURL)
	{
		string filename = GetFilenameForURL(sourceURL);
		
		BitmapImage image;
		
		if (!FileExists(filename))
		{
			image = DownloadAndSaveImage(sourceURL, filename);
		}
		else		
		{		
			image = ReadImageFile(filename);
		}
		
		return image;
	}
