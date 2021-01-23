    List<string> resultsList = new List<string);
    
    for(int i = 0; i < preferences.Count; i++)
    {
        List<string> tempList = new List<string);
        //creating the substring eliminates the "preferences = '" as well as the "'" at end of string
        //this line also splits each string from the preferences string list into the tempList array
        tempList = preferences[i].Substring(15, preferences[i].Length - 15 - 1).Split('.').ToList();
    
        string buildFinalString = "";
        
        //traverse tempList and only add string to buildFinalString if it does not contain "hate"
        foreach(string x in tempList)
        {
            if(!x.Contains("hate").ToUpper() || !x.Contains("hate").ToLower())
            {
                 buildFinalString = buildFinalString + " " + x;
            }
        }
        resultsList.Add(buildFinalString);
    }
