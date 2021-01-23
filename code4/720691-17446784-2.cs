    public void WriteList(IEnumerable<object> input, string ListName)
    {
        WriteToFile("List - " + ListName);
        foreach (object temp in input)
        {
            WriteToFile(temp.ToString());
        }
    }
