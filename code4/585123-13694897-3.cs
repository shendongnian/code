    IEnumerable<string> GetSubsectionLines(string theWholeThing, string subsectionTitle)
    {
        bool foundSubsectionTitle = false;
        foreach(var line in BreakIntoLines(theWholeThing))
        {
            if(line.Contains(subSectionTitle))
            {
                foundSubsectionTitle = true; //Start capturing
            }
            
            if(foundSubsectionTitle)
            {
                yield return line;
            } //Implicit "else" - Just discard the line if we haven't found the subsection title yet
            if(String.IsNullOrWhiteSpace(line))
            {
                //This will stop iterating after returning the empty line, if there is one
                yield break;
            }
        }
    }
