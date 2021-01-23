	private String _filename;
	void saveToolStripMenuItem_Click()
	{
		if (String.IsNullOrEmpty(_filename))
		{
			if (ShowSaveDialog() != DialogResult.OK)
			{
				return;
			}
		}
		
		SaveCurrentFile();
	}
	void saveAsToolStripMenuItem_Click()
	{
		if (ShowSaveDialog() != DialogResult.OK)
		{
			return;
		}
		
		SaveCurrentFile();
	}
	DialogResult ShowSaveDialog()
	{
		var dialog = new SaveFileDialog();
		// set your path, filter, title, whatever
		var result = dialog.ShowDialog();
		
		if (result == DialogResult.OK)
		{
			_filename = result.FileName;
		}
		
		return result;
	}
	void SaveCurrentFile()
	{
		using (var writer = new StreamWriter(_filename))
		{
			// write your file
		}
	}
