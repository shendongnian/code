    public string DoGeneralReplace(string input)
    {
        var sb = new StringBuilder(input);
        sb.Replace('^', 'Č')
          .Replace('@', 'Ž') ...;
    }
    //usage
    foreach (var oldObj in oldDB)
    {
        NewObject newObj = new NewObject();
        newObj.Name = DoGeneralReplace(oldObj.Name);
        ...
    }
