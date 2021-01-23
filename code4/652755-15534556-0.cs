    List<string> lines = new List<string>(System.IO.File.ReadAllLines(MyFile));
    lines.Add(sName + " by " + aName);
    int lineCount = lines.Count;
    //limit reached
    if(lineCount > 100 )
    {
        //TODO: overlimit code
    } else {
        System.IO.File.WriteAllLines(MyFile, lines.ToArray());
    }
