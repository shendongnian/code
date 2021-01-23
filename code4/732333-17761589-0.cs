    Dictionary<int,int> occurences = new Dictionary<int,int>();
    int numberOfLists = YourCollectionOfOuterLists.Count;
    foreach (string list in YourCollectionOfOuterLists) {
        foreach (string value in list.Split(',')) {
            occurences[value] = ((occurences[value] as int) ?? 0) + 1;
        }
    }
    List<int> output = new List<int>();
    foreach (int key in occurences.Keys) {
        if (occurences[key] == numberOfLists) {
            output.Add(key);
        }
    }
    return String.Join(output.Select(x => x.ToString()), ",");
