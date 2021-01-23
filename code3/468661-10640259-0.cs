    private void OnNewMessage(string message) 
    {
       if(message.Contains("logged in")) 
       {
          // Build player object
          // some code here ... to parse the string
          // Add to player dictionary
          PlayerDict.Add(playerName, newPlayerObject);
       }
       else if(message.Contains("disconnect")) 
       {
          // Find the player object by parsing the string
          PlayerDict.Remove(playerName);
       }
    }
