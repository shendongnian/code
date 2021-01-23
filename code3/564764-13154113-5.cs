    public bool NameStartsWith(string name,string searchStr)
    {
        var split = name.Split(" ");
        foreach(var str in split)
        {
            if(str.StartsWith(searchString))
              return true;
        }
        return false;
    }
