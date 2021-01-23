    public static void Main (string[] args)
    {
    	char[] punctiationMarks = new char[]{'.', ',', '?', '!', ';', ')'};
    	string inputString = "foo; bar;foo ,  bar , foo\nbar, foo ) bar foo  )bar";
    	StringBuilder outputString = new StringBuilder ();
    	int indexOfPunctuationMark = -1;
    	inputString
    		.Split (punctiationMarks, StringSplitOptions.None)
    		.ToList ()
    			.ForEach (part => {
    				indexOfPunctuationMark += part.Length + 1;
    				outputString.Append (part.Trim ());
    				if (indexOfPunctuationMark < inputString.Length)
    					outputString.Append (inputString [indexOfPunctuationMark]).Append (" ");
    			}
    	);
    
    	Console.WriteLine (outputString);
    }
