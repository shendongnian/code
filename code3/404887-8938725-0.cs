    private void UnloadBadAddins(bool unloadAddin)
    {
    	const string badAddin = "iManage Excel2000 integration (Ver 1.3)";
    
    	foreach(Office.COMAddIn addin in this.ExcelApp.COMAddIns)
    	{
    		if (addin.Description.ToUpper().Contains(badAddin.ToUpper()))
    		{
    			if (addin.Connect == unloadAddin)
    			{
    				addin.Connect = !unloadAddin;
    				return;
    			}
    		}
    	}
    }
