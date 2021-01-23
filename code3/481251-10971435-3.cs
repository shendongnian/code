    string[] Files = System.IO.Directory.GetFiles("Directory_To_Look_In");
    foreach (string sFile in Files)
    {
        string fileCont = System.IO.File.ReadAllText(sFile);
        if (fileCont.Contains("WordToLookFor") == true)
        {
            //it found something
        }
    }
