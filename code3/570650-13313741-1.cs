    List<string> headers = new List<string>();
    string line;
    bool inHeader = false;
    StringBuilder header = new StringBuilder();
    while((line = reader.ReadLine()) != null)
    {
        if(!inHeader)
        {
            if (line == "#Header") inHeader = true;
        }
        else if (line == "#Content")
        {
            headers.Add(header.ToString());
            header.Clear();
            inHeader = false;
        }            
        else
        {
            header.AppendLine(line);
        }
    }
        
    if(inHeader) headers.Add(header.ToString());
