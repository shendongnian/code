    string line;
    List<string> stdList = new List<string>();
    
    StreamReader file = new StreamReader(myfile);
    while ((line = file.ReadLine()) != null)
    {
        stdList.Add(line);
        var trash = file.ReadLine();  //get rid of a line
    }
    finally
    {
    }
