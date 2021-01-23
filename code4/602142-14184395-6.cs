    class Token
    {
        public string Value { get; set; }
    	
        public IEnumerable<string> GetAllValues()
        {
            if(IsRange(Value))
            {
                var rangeValues = Value.Split(new[] {'[', '-', ']'}, StringSplitOptions.RemoveEmptyEntries);
    			//numeric format defines minimal string length. [01-10] will have numericFormat = "{0:00}"
    			string numericFormat = CreateNumericFormat(rangeValues.ElementAt(0).Length);
    			
                int[] ranges = rangeValues.Select(val => int.Parse(val)).ToArray();
    			
                foreach (var val in GetRange(ranges[0], ranges[1]))
                    yield return string.Format(numericFormat, val);
            }
            else
            {
                yield return Value;
            }
        }
        //validation is ommited
        private bool IsRange(string val)
        {
            return Value.Contains("-");
        }
    	private string CreateNumericFormat(int minimalLength)
    	{
    		return "{0:"+new string('0', minimalLength)+"}";
    	}
        private IEnumerable<int> GetRange(int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, maxValue - minValue + 1);
        }
    }
