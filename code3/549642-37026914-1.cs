    int counter = 0;
    object xamlClipData = null;
    
    while (xamlClipData == null)
    {
    	try
    	{
    		if (counter > 10)
    		{
    			System.Windows.MessageBox.Show("...");
    			break;
    		}
    
    		counter++;
    
    		if (System.Windows.Clipboard.GetDataObject().GetDataPresent(DataFormats.Xaml))
    		{
    			xamlClipData = System.Windows.Clipboard.GetData(DataFormats.Xaml);
    		}
    	}
    	catch { }
    }
