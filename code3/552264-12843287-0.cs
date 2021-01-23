    string fileContents = System.IO.File.ReadAllText(@"d:\Keywords.txt");
    if(fileContents.Contains(line))
    {
        //Desired code here
    }
    else
    {
        w.WriteLine(line);
    }
