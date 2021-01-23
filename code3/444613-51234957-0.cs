    int CountJTokenProperties(JToken token)
    {
        var sum = 0;
    
        if (token.Type == JTokenType.Object)
        {
            foreach (var child in token.Value<JObject>())
            {
                sum += CountJTokenProperties(child.Value);
            }
        }
        else if (token.Type == JTokenType.Array)
        {
            foreach (var child in token.Value<JArray>())
            {
                sum += CountJTokenProperties(child);
            }
        }
        else
        {
            sum += 1;
        }
    
        return sum;
    }
