    object xamlClipData = null;
    
    while (xamlClipData == null)
    {
    	try
    	{
    		if (System.Windows.Clipboard.GetDataObject().GetDataPresent(DataFormats.Xaml))
    		{
    			xamlClipData = System.Windows.Clipboard.GetData(DataFormats.Xaml);
    		}
    	}
    	catch { }
    }
