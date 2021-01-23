    private Dictionary<string, string> userMap = new Dictionary<string, string>();
    string getLine(string userId, List<string> lines_secondFile) 
    {
        if(userMap.ContainsKey(userId))
            return userMap[userId];
        else
        {
          foreach (string currentLine in lines_secondFile) 
          {
            if (currentLine.Contains(userId)) 
            {
                userMap.Add(userId, currentLine);
                return currentLine;
            }
        }
        return null;
    }
