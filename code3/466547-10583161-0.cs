    string[] arFiles = Directory.GetFiles(@"C:\");
    
    foreach (var sFilename in arfiles)
    {
        // Open file named sFilename for reading, do whatever
        using (StreamReader sr = File.OpenText(sFilename )) 
        {
            string s = "";
            while ((s = sr.ReadLine()) != null) 
            {
                Console.WriteLine(s);
            }
        }
    }
