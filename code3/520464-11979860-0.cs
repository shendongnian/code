    void DirectoryIntoThumbNails(string sDir, string extension) 
    {
    	try	
    	{
    	   foreach (string d in Directory.GetDirectories(sDir)) 
    	   {
    		foreach (string f in Directory.GetFiles(d, extension)) 
    		{
    		   SystemDiagnostics.Process.Start(@"C:\Ffmpeg.exe " + f + commandYouUsedSuccessfullyOnOneFile)
    		}
    		//Uncomment this if you want it to be recursive - all sub folders
            //DirSearch(d, extension);
    	   }
    	}
    	catch (System.Exception excpt) 
    	{
    		Console.WriteLine(excpt.Message);
    	}
    }
