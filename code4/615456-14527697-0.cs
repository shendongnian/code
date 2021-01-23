    public static void StartBruteForce(string start)
    {
       /*change 5*/ StringBuilder sb = new StringBuilder(start);
       /*sugg 3*/ int counter = ChangeCharacters(0, /*change 1*/ true, sb);
       Console.WriteLine(counter);
    }
    
    private static int ChangeCharacters(int pos, /*change 1*/ bool firstPass , StringBuilder sb)
    {
    	/*sugg 3*/ int counter = 0;
    	for (int i = /*change 2*/ firstPass ? Charset.IndexOf(sb[pos]) : 0; /*sugg 2*/ i < Charset.Length; i++)
    	{                
    		sb[pos] = Charset[i];
    		if (pos == /*sugg 1*/ sb.Length - 1)
    		{
    			counter++;
    			Console.WriteLine(sb.ToString());
    		}
    		else
    		{
    			/*sugg 3*/ counter += ChangeCharacters(pos + 1, /*change 3*/ firstPass, sb);
    			/*change 4*/ firstPass = false;
    		}
    	}
    	/*sugg 3*/ return counter;
    }
