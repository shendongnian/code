    using (StreamReader sr = new StreamReader(@"text file"))
    {
     string line;
     while ((line = sr.ReadLine()) != null)
     {
         if (line.StartsWith("some character"))
         {
            //Get rid of line
         }
         else
         {
           // Do stuff with the lines you want
         }  
