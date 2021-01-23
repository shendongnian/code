    public string DecodeSpecificTags(List<string> whiteListedTagNames,string encodedInput)
    {
        String decodedOutput="",regex="";
        foreach(string s in whiteListedTagNames)
        {
            regex="&lt;"+"/?"+s+"&gt";
            decodedOutput=Regex.Replace(encodedInput,regex);
        }
        return decodedOutput;
    }
