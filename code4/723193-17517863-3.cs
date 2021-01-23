    string inputSentence = "blah 1 2 3 7-Jul-13 6:15:00 4 5 6 blah";
    string dtformat = "d-MMM-yy H:mm:ss";
    //convert dtformat into regex pattern
    StringBuilder sb = new StringBuilder();
    foreach (char c in dtformat)
    {
        if (Char.IsLetter(c))
        {
           if (char.ToUpperInvariant(c) == 'D' || char.ToUpperInvariant(c) == 'H' || char.ToUpperInvariant(c) == 'S')            
              sb.Append(".{1,2}");
           else
              sb.Append(".");
        }
        else if(Char.IsWhiteSpace(c))        
           sb.Append("\\s");
        else
           sb.Append(c);
    }
    
   
    string dtPattern = sb.ToString();
    Regex dtrx = new Regex(dtPattern);
    //get the match using the regex pattern
    var dtMatch = dtrx.Match(inputSentence);
    if(dtMatch != null)
    {
        string firstString = dtMatch.Value.Trim();
 
        //try and parse the datetime from the string
        DateTime firstMatch;
        if (DateTime.TryParseExact(dstr, dtformat, null, DateTimeStyles.None, out firstMatch))
        {
           Console.WriteLine("Parsed");
        }
        else
        {
           Console.WriteLine("Could not parse");
        }
    }
