     FileInfo fi1 = new FileInfo(path);
    
            //Create a file to write to.
            using (StreamWriter sw = fi1.CreateText()) 
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }	
    
            //Open the file to read from.
            using (StreamReader sr = fi1.OpenText()) 
            {
                string s = "";
                while ((s = sr.ReadLine()) != null) 
                {
                    Console.WriteLine(s);
                
                }
             } 
