    string[] stopWords = new string[]
    {
        "string1",
        "string2"
    }
    using(StreamReader sr = File.OpenText(srcPath))
    using(StreamWriter sw = File.OpenText(outPath))
    {
        while ((stringToRemove = sr.ReadLine()) != null)
        {
            if (!stopWords.Any(s => stringToRemove.Contains(s))
            {
                sw.WriteLine(stringToRemove);
            }
        }
    }
    File.Move(outPath, srcPath);
