    class Token
    {
    	private string value;
    	public Token(string value)
    	{
    		this.value = value;
    	}
    	
    	public IEnumerable<string> GetAllValues()
    	{
    		if(IsRange(value))
    		{
    			int[] rangeValues = value.Split(new[] {'[', '-', ']'}, StringSplitOptions.RemoveEmptyEntries)
    							         .Select(val => int.Parse(val))
    							         .ToArray();
    							   
			    foreach (var val in GetValuesForRange(rangeValues))
		   		    yield return val.ToString();;
    		}
    		else
    		{
    			yield return value;
    		}
    	}
    	//validation is ommited
    	private bool IsRange(string val)
    	{
    		return value.Contains("-");
    	}
    	
    	private IEnumerable<int> GetValuesForRange(int[] minMaxRanges)
    	{
    		return Enumerable.Range(minMaxRanges[0], minMaxRanges[1] - minMaxRanges[0] + 1);
    	}
    }
