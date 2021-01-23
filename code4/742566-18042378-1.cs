    public static SomeObject Deserialize(IEnumerable<string> input)
    {
        var result = new SomeObject();
        foreach (var dataLine in input.Skip(1))
        {
            var dataElements = dataLine.Split('|');
            result.Start = DateTime.Parse(dataElements.Skip(6).First());
            result.Stop = DateTime.Parse(dataElements.Skip(7).First());
        }
        return result;
    }
