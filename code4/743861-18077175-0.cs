    public Setting TestSettings(Example _example, String type)
    {
        var results = _example.GetExample("Testing");
        if (results.Key == type)
        {
            // whatever you need to do here
        }
        return results;
    }
