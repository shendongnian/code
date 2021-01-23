    public string MyPackageQueryString(Package package) 
    {
        var myTerms = List<string>();
        myTerms.Add(package.Name);
        if (package.TargetBusiness != null)
        {
            myTerms.Add(package.Industry)
            ....
        }
        ...
        return string.Join(" ", myTerms.Where(t=>!string.IsNullOrWhiteSpace(t)));
    }
