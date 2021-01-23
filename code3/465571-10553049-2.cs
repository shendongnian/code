    public static BigInteger NextPalindrome(BigInteger input)
    {
    	string firstHalf=input.ToString().Substring(0,(input.ToString().Length+1)/2);
    	string incrementedFirstHalf=(BigInteger.Parse(firstHalf)+1).ToString();
    	var candidates=new List<string>();
    	candidates.Add(firstHalf+new String(firstHalf.Reverse().ToArray()));
    	candidates.Add(firstHalf+new String(firstHalf.Reverse().Skip(1).ToArray()));
    	candidates.Add(incrementedFirstHalf+new String(incrementedFirstHalf.Reverse().ToArray()));
    	candidates.Add(incrementedFirstHalf+new String(incrementedFirstHalf.Reverse().Skip(1).ToArray()));
    	candidates.Add("1"+new String('0',input.ToString().Length-1)+"1");
    	return candidates.Select(s=>BigInteger.Parse(s))
    			  .Where(i=>i>input)
    			  .OrderBy(i=>i)
    			  .First();
    }
