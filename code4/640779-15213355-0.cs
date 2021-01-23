    public IList ResultsList 
    {
        get 
        {
            if (ResultingType == typeof(string)) 
            {
                return strings;
            }
            if (ResultingType == typeof(int)) 
            {
                return ints; //hardcoded demo 
            }
            if (ResultingType == typeof(char)) 
            {
                return chars;
            }
            // not one of the above types
            return null;
        }
    }
