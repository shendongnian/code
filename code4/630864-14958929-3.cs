    int IntegerBuilderFactory(string stringToParse)
    {
        int result;
        if(!int.TryParse(stringToParse, out result))
        {
            // insert logging here
            return 0;
        }
        return result;
    }
