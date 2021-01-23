    public string DecodeSpecificTags(List<string> whiteListedTagNames,string encodedInput)
    {
        String regex="";
        foreach(string s in whiteListedTagNames)
        {
            regex="&lt;"+"/?"+s+"&gt";
            encodedInput=Regex.Replace(encodedInput,regex);
        }
        return encodedInput;
    }
