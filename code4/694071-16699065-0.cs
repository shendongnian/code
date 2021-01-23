    string settings = string.Empty;
    IEnumerable<string> lines = File.ReadLines(myPath); //reads all lines of text file
    foreach (string s in lines) //iterate thru all lines
    {
        if s.Contains("=")
        {
            settings = s.substring(s.IndexOf("=")); //get substring from "=" to end of line
            break; //break out of the loop
        }
    }
