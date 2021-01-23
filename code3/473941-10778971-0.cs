    IList<string> getSection(string sectionName)
    {
        StreamReader sr = new StreamReader(@"C:\Path\To\file.txt");
        string line;
        var MyList = new List<string>();
        bool inCorrectSection = false;
        while ((line = sr.ReadLine()) != null)
        {
            if (line.StartsWith("#"))
            {
                if (inCorrectSection)
                    break;
                else
                    inCorrectSection = line.Substring(1) == sectionName;
            }
            else if (inCorrectSection)
                MyList.Add(line);
        }
        return MyList;
    }
    // in another method
    wordList.DataSource = getSection("headword1");
