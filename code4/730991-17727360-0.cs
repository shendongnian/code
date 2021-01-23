    public List<MyClass> Parse(string base, string workingName, string workingValue,
                               bool processingName = true, 
                               List<MyClass> workingList = null, int index = 0)
    {
        if (workingList == null)
            workingList = new List<MyClass>();
        if (index >= base.Length)
        {
            return workingList;
        }
        if (base[index] = '|')
        {
            workingList.Add(new MyClass { keyName = workingName, keyValue = workingValue });
            return Parse(base, "", "", true, workingList, index + 1);
        }
        else if (base[index] = ':')
        {
            return Parse(base, workingName, "", false, workingList, index + 1);
        }
        else if (processingName)
        {
            return Parse(base, workingName + base[index], "", processingName, workingList, index + 1);
        }
        else
        {
            return Parse(base, workingName, workingValue + base[index], processingName, workingList, index + 1);
        }
    }
