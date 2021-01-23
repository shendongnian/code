  		if (!System.IO.Directory.Exists(filename))
		{
			openDlg.InitialDirectory =
				System.IO.Path.GetDirectoryName(filename);
		}
