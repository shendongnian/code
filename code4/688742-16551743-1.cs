    FileStream fsIn = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
    using (StreamReader sr = new StreamReader(fsIn))
     {
         line = sr.ReadLine();
         while (!String.IsNullOrEmpty(line)
         {
            line = sr.ReadLine();
           //call isNumberValid on each line, store results to list
         }
     }
 
