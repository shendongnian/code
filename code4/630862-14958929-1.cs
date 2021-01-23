    int IntegerBuilderFactory(string stringToParse)
    {
        int result;
        if(!int.TryParse(result))
        {
            // insert logging here
            return 0;
        }
        return result;
    }
