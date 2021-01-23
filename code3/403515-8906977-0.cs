    public static void NullAndRelease(object o)
    {
    	if (o == null) {
    		return;
    	}
    
    	try {
    		int releaseResult = 0;
    		do {
    			releaseResult = System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
    		} while (releaseResult >= 0);
    	} catch {
    	} finally {
    		GC.Collect();
    		GC.WaitForPendingFinalizers();
    	}
    }
