    public static void writelogfile(string text) 
    { 
        
    	lock(myLock)
            {
               //Using instead of close in case there's an error with WriteLine
       	       using(StreamWriter sw = logfile.AppendText()) 
               { 
     	        sw.WriteLine(text); 
               }
            }
    }
