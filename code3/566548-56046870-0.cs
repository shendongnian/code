    using Microsoft.Office.Interop.Excel;
    
    class WorksheetDecoratorImpl
    {
    	public Worksheet Worksheet { get; private set; }
    
    	public string Name => Worksheet.Name;
    
    	public void TryClearAllFilters()
    	{
    		try
    		{
    			if (Worksheet.AutoFilter != null)
    			{
    				Worksheet.AutoFilterMode = false;
    			}
    		}
    		catch(Exception ex)
    		{
    			//Log.Error(string.Format("Clear filters encountered an issue. Sheet: {0}", Name));
    		}
    		try
    		{
    			ListObjects listObjects = Worksheet.ListObjects;                
                foreach(ListObject listObject in listObjects)
                {
                    listObject.AutoFilter.ShowAllData();
                }
    		}
    		catch (Exception ex)
    		{
    			//Log.Error(string.Format("Clear table filters encountered an issue. Sheet: {0}", Name));
    		}
    	}
    }
