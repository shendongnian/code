     string buffer = null;
     using (System.IO.FileStream stm = new 
         System.IO.FileStream("c:\\YourFile.txt",System.IO.FileMode.Open,  
         System.IO.FileAccess.Read, System.IO.FileShare.None))
         {
             using (System.IO.StreamReader rdr = new System.IO.StreamReader (stm))
             {
                            buffer=rdr.ReadToEnd();
             }
         }
