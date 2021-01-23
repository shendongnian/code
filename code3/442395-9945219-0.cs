    Regex regStatus = new Regex(@"^Status:");
    Regex regTitle = new Regex(@"^Title:");
    string line;
    string[] decriptionLine;
    string[] statusLine;
    string[] titleLine;
    using(TextReader reader = File.OpenText("file.txt"))
    {
        while(reader.Peek() > 0)
        {
           line = reader.ReadLine();
           if(regStatus.IsMatch(line))
           {
              // status line, convert to array, can drop first element as it is "status"
              statusLine = line.Split(' '); 
              // do stuff with array
           }
           else if(regTitle.IsMatch(line))
           {
              // title line, convert to array can drop first element as it is "title"
              titleLine = line.Split(' ');
              // do stuff with array
           }
           else
           {
              // description line, so just split into array
              decriptionLine = line.Split(' ');
              // do stuff with array
           }
        }
    }
