	List<...> m_files = Directory.EnumerateFiles(folder);
	wordApp.DocumentBeforeClose += ProcessNextDocument;
	...
	void ProcessNextDocument(...)
	{
		File file = null;
		lock(m_files)
		{
			if (m_files.Count > 0)
			{
				file = m_files[m_files.Count - 1];
				m_files.RemoveAt(m_files.Count - 1);
			}
			else
			{
				// Done!
			}
		}
		
		if (file != null)
		{
			PrintDocument(file);
		}
	}
	void PrintDocument(File file)
	{
		wordApp.Document.Open(...);
		wordApp.Document.PrintOut(...);
		wordApp.ActiveDocument.Close(...);
	}
