    class Token
    {
        public string Value { get; set; }
    
        public IEnumerable<string> GetAllValues()
        {
            if(IsRange(Value))
            {
                int[] rangeValues = Value.Split(new[] {'[', '-', ']'}, StringSplitOptions.RemoveEmptyEntries)
                                         .Select(val => int.Parse(val))
                                         .ToArray();
    
                foreach (var val in GetValuesForRange(rangeValues))
                    yield return val.ToString();;
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
    
        private IEnumerable<int> GetValuesForRange(int[] minMaxRanges)
        {
            return Enumerable.Range(minMaxRanges[0], minMaxRanges[1] - minMaxRanges[0] + 1);
        }
    }
