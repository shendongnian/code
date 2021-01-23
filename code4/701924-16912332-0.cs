    public bool FileIsLocked(string strFullFileName)
    {
    	bool blnReturn = false;
    	System.IO.FileStream fs = null;
    
    	try {
    		fs = System.IO.File.Open(strFullFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read, System.IO.FileShare.None);
    		fs.Close();
    	} catch (System.IO.IOException ex) {
    		blnReturn = true;
    	}
    
    	return blnReturn;
    }
