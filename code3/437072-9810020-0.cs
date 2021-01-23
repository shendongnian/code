    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    	// First we see the input string.
    	string input = "Lorem {placeholder} ipsum {placeholder2} ...";
    
    	// Here we call Regex.Match.
    	Match match = Regex.Match(input, @"(?<=\{)(.*)(?=\})",
    	    RegexOptions.IgnoreCase);
    
    	// Here we check the Match instance.
    	if (match.Success)
    	{
    	    // Finally, we get the Group value and display it.
            foreach(var matchgroup in match.Groups)
                Console.WriteLine(matchgroup.Value);
    	}
        }
    }
