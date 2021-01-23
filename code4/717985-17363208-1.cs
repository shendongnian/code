    string filename = "yourfilename";
    Regex r = new Regex(@"(?<rowsaffected>(?<=Rows_affected:\s)[0-9]*)");
    int lineNumber = 1;            
    using(TextReader reader = new StreamReader(filename))
    {
        string line = reader.ReadLine();
        while(line != null)
        {
            Match m = r.Match(line);
            int rowsaffected = int.Parse(m.Groups["rowsaffected"].Value);
            if(rowsaffected > 500)
            {                        
                // do whatever you want with your linenumber here.
            }
            lineNumber++;
            line = reader.ReadLine();
        }
    }
