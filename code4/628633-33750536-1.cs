        public static IDictionary<char, int> CharValues 
        { 
            get 
            { 
                return new Dictionary<char, int>
                {{'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}};
            } 
        }
        
        public static int RomanNumeralToInteger(IEnumerable<char> romanNumerals)
        {
            int retVal = 0;
            //go backwards
            for (int i = romanNumerals.Count() - 1; i >= 0; i--)
            {
                //get current character
                char c = romanNumerals.ElementAt(i);
                //error checking
                if (!CharValues.ContainsKey(c)) throw new InvalidRomanNumeralCharacterException(c);
                //determine if we are adding or subtracting
                bool op = romanNumerals.Skip(i).Any(rn => CharValues[rn] > CharValues[c]);
                
                //then do so
                retVal = op ? retVal - CharValues[c] : retVal + CharValues[c];
            }
            return retVal;
        }
