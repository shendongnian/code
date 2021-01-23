    string ReplaceLocation(string input, IList<string> replacements)
    {
        string locString = "Location ";
        int matchDigitStart = 0;
        int matchDigitEnd = 0;
        int matchStart = 0;
     
        do{
            matchStart = input.IndexOf(locString, matchDigitStart);
            if(matchStart == -1)
            {
                throw new ArgumentException("Input string did not contain Location identifier", "input");
            }
            matchDigitStart = matchStart + locString.Length;
            matchDigitEnd = matchDigitStart;
            while(matchDigitEnd < input.Length && Char.IsDigit(input[matchDigitEnd]))
            {
                ++matchDigitEnd;
            }
         
        } while (matchDigitEnd == matchDigitStart);
         
            
        int locationId = int.Parse(input.Substring(matchDigitStart, matchDigitEnd - matchDigitStart));
        if(locationId > replacements.Count || locationId == 0 )
        {
            throw new ArgumentException("Input string specified an out-of-range location identifier", "input");
        }
        return input.Substring(0, matchStart) + replacements[locationId - 1] + input.Substring(matchDigitEnd);
    }
