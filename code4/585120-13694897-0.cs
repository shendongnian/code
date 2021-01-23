    IEnumerable<string> BreakIntoLines(string theWholeThing)
    {
        int startIndex = 0;
        int endIndex = 0;
        for(;;)
        {
            endIndex = theWholeThing.IndexOf(Environment.NewLine,startIndex) + Environment.NewLine.Count; //Remember to pick up the newline character(s) too!
            if(endIndex = -1) //Didn't find a newline
            {
                //Return the end part of the string and finish
                yield return theWholeThing.SubString(startIndex);
                yield break;
            }
            else //Found a newline
            {
                //Return where we're at up to the newline
                yield return theWholeThing.SubString(startIndex, endIndex - startIndex);
                startIndex = endIndex;
            }
        }
    }
