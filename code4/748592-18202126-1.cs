         // Read each line of the file into a string array. Each element 
         // of the array is one line of the file. 
         string[] lines = System.IO.File.ReadAllLines(@"C:\yourFile.txt");
         foreach (string line in lines)
         {
            string sub = line.Substring(line.IndexOf("GeneratedNumber=") + 1);
            int num = int.Parse(sub.IndexOf("\""));
            // whatever you want to do with the integer
         }
