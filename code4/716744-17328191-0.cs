    string filePath = "MickeyMoust.txt";
    bool append = false;
    List<MyClassA> myClassAs = new List<MyClassA> { new MyClassA() };
        List<char[]> outputLines = new List<char[]>();
    
    foreach (MyClassA myClassA in myClassAs)
    {
        outputLines.Add(myIO.GetCharArray(myClassA));
    
        if (myClassA.MyClassBs != null)
            outputLines.AddRange(myClassA.MyClassBs.Select(myClassB => myIO.GetCharArray(myClassB)));
    
        if (myClassA.MyClassCs != null)
            outputLines.AddRange(myClassA.MyClassCs.Select(myClassC => myIO.GetCharArray(myClassC)));
    }
    
    var lines = outputLines.Select(line => string.Concat<char>(line));
    if (append)
        File.AppendAllLines(filePath, lines);
    else
        File.WriteAllLines(filePath, lines);
