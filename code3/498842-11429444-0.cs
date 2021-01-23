	private String _filename;
	void saveToolStripMenuItem_Click()
	{
		if (String.IsNullOrEmpty(_filename))
		{
			var result = ShowSaveDialog();
			if (result != DialogResult.OK)
			{
				return;
			}
			
			_filename = result.FileName;
		}
		
		SaveCurrentFile();
	}
	DialogResult ShowSaveDialog()
	{
		var dialog = new SaveFileDialog();
		// set your path, filter, whatever
		return dialog.ShowDialog();
	}
	void SaveCurrentFile()
	{
		using (var writer = new StreamWriter(_filename))
		{
			// write your file
		}
	}
