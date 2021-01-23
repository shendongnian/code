    List<Dictionary<char,int>> listOfPNObjects = new List<Dictionary<char,int>>();
    listOfPNObjects.Add(new Dictionary<char,int>())    //create default P dictionary
    foreach(entry in collection) {
        if(entry.Key == N)
        {
                listOfPNObjects.Add(new Dictionary<char,int>());
        }
        else
        {
              listOfPNObjects[listOfPNObjects.Count - 1].Add(entry.key, entry.value);
        }
    }
