    public void Process()
    {
        // logic to get string[] of filenames here. You could loop through each
        // day you need a list for and generate a filename for the given day
        var values = new List<T>();
        foreach (var filename in filenames)
        {
            var valuesFromFile = GetValuesFrom(filename);
            values.AddRange(valuesFromFile);
        }
        ProcessValues(values);
    }
    private List<T> GetValuesFrom(string filename)
    {
        var values = new List<T>();
        while loop //this goes through all the lines in the file. 
        {if //if meets certain criteria then store into a list, otherwise ignore
        }
        return values;
    }
    private void ProcessValues(List<T> values)
    {
        foreach // this part does the analysis of all the values in the list, totals, etc
    }
