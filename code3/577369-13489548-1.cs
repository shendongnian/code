    public object MyUDF(string TopicID, string TopicName)
    {
        var value = _xlApp.WorksheetFunction.RTD("my_rtdserver", null, TopicID, TopicName);
        double num;
        if (!double.TryParse(value, out num))
    		return value;
        return num;
    }
