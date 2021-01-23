    DirectoryInfo di = new DirectoryInfo("c:\\codeo\\");
    FileInfo[] fiArray = di.GetFiles();
    foreach (FileInfo fi in fiArray)
    {
        StreamReader objReader = new StreamReader(fi.FullName);
        string sLine = "";
        ArrayList arrText = new ArrayList();
        while (sLine != null)
        {
            sLine = objReader.ReadLine();
            if (sLine != null)
                arrText.Add(sLine);
        }
        objReader.Close();
        foreach (string sOutput in arrText)
            Console.WriteLine(sOutput);
        Console.ReadLine();
    }
