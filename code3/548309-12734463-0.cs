    FileInfo file = new FileInfo("MyHugeXML.xml");
    FileInfo outFile = new FileInfo("ResultFile.xml");
    
    using(FileStream write = outFile.Create())
    using(StreamReader sr = file.OpenRead())
    {
        bool foundit = false;
        string line;
        while((line = sr.ReadLine()) != null)
        {
            if(foundit)
            {
                write.WriteLine(line);
            }
            else if (line.Contains("<etc123"))
            {
                foundit = true;
            }
        }
    }
