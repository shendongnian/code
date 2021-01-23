    public bool IsMatching(string Name, string SearchOption)
    {
        foreach (string s in Name.Split(' '))
        {
           if s.StartsWith(SearchOption)
              return true;
        }
        return false;
    }
    // use it like:
    if IsMatching("Sameer Singh", "Sa")
    {
        // ...
