    public string GenerateMessage<T>(string messageID, Dictionary<string, T> values)
    {
        string gameMessage = gameMessages[messageID];
        var template = new StringTemplate(gameMessage);
        foreach (var value in values)
        {
            template.SetAttribute(value.Key, value.Value);
        }
        return template.ToString();
    }
