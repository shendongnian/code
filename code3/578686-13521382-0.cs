    string[] FileList;
                
    if (e.Data.GetDataPresent(DataFormats.FileDrop))
    {
    	FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
    }
    else if (e.Data.GetDataPresent(DataFormats.StringFormat))
    {
    	FileList = new string[] {e.Data.GetData(DataFormats.StringFormat, false).ToString()};
    }
    else
    {
    	return;
    }
