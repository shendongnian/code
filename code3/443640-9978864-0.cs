    int Unique(string parameterName)
    {
        List<Whatever> subList = new List<Whatever>();
        if (parameterName == "Id")
        {
            subList = data.Select(x => x.Id);
        } else {
            subList = data.Select(x => x.Name)
        }
    
        return subList.Distinct().Count();
    }
