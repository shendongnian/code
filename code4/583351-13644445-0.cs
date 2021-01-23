    public void ContainsDictKey(Dictionary<Dictionary<string, List<ChatClient>>, IGame> games, string key)
    {
        foreach(var l in games)
        {
            if(l.Key.ContainsKey(key))
                return true;
        }
        return false;
    }
  
