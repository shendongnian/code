    void Main()
    {
    	string str1 = "ðə ɻɛd fɑks ɪz hʌŋgɻi";
    	string str2 = "ðæt ɪt foks ɪn ðʌ sʌn ɻe͡i";
    	Console.WriteLine(StringCompare(str1,str2)); //34.6153846153846
    	Console.WriteLine(StringCompare("same","same")); //100
    	Console.WriteLine(StringCompare("","")); //100
    	Console.WriteLine(StringCompare("","abcd")); //0  
    }
    
    static double StringCompare(string a, string b)
    {
        if (a == b) //Same string, no iteration needed.
    		return 100;
    	if ((a.Length == 0) || (b.Length == 0)) //One is empty, second is not
    	{
    		return 0;
    	}
    	double maxLen = a.Length > b.Length ? a.Length: b.Length;
    	int minLen = a.Length < b.Length ? a.Length: b.Length;
    	int sameCharAtIndex = 0;
    	for (int i = 0; i < minLen; i++) //Compare char by char
    	{
    		if (a[i] == b[i])
    		{
    			sameCharAtIndex++;
    		}
    	}
    	return sameCharAtIndex / maxLen * 100;
    }
