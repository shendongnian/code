    static class Example
    {
    	public static XmlTextWriter GetWriterForFolder(string fileName, Encoding encoding)
    	{
    		FolderBrowserDialog dlg = new FolderBrowserDialog();
    		if (dlg.ShowDialog() != DialogResult.OK)
    			return null;
    
    		XmlTextWriter writer = new XmlTextWriter(Path.Combine(dlg.SelectedPath, fileName), encoding);
    		writer.Formatting = Formatting.Indented;
    
    		return writer;
    	}
    
    	public static XmlTextWriter GetWriterForFile(Encoding encoding)
    	{
    		SaveFileDialog dlg = new SaveFileDialog();
    		dlg.Filter = "XML Files (*.xml)|*.xml";
    
    		if (dlg.ShowDialog() != DialogResult.OK)
    			return null;
    
    		XmlTextWriter writer = new XmlTextWriter(dlg.FileName, encoding);
    		writer.Formatting = Formatting.Indented;
    
    		return writer;
    	}
    }
