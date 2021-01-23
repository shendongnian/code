    string[] Files = System.IO.Directory.GetFiles("Directory_To_Look_In");
    if (Files.Length > 0)
    {
        foreach (string sFile in Files)
        {
            string fileCont = File.ReadAllText();
            if (fileCont.Contains("WordToLookFor") == true)
            {
                //it found something
            }
        }
    }
