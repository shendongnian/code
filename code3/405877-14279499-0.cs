    static void Main(string[] args)
    {
        Dictionary<string, string> nodes = new Dictionary<string, string>();
        // put your JSON object here
        JObject rootObject = JObject.Parse("{\"world\": {\"hello\": \"woo\", \"foo\": \"bar\", \"arr\": [\"one\", \"two\"]}}");
        ParseJson(rootObject, nodes);
        // nodes dictionary contains xpath-like node locations
        Debug.WriteLine("");
        Debug.WriteLine("JSON:");
        foreach (string key in nodes.Keys)
        {
            Debug.WriteLine(key + " = " + nodes[key]);
        }
    }
    /// <summary>
    /// Parse a JSON object and return it as a dictionary of strings with keys showing the heirarchy.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="nodes"></param>
    /// <param name="parentLocation"></param>
    /// <returns></returns>
    public static bool ParseJson(JToken token, Dictionary<string, string> nodes, string parentLocation = "")
    {
        if (token.HasValues)
        {
            foreach (JToken child in token.Children())
            {
                if (token.Type == JTokenType.Property)
                    parentLocation += "/" + ((JProperty)token).Name;
                ParseJson(child, nodes, parentLocation);
            }
            // we are done parsing and this is a parent node
            return true;
        }
        else
        {
            // leaf of the tree
            if (nodes.ContainsKey(parentLocation))
            {
                // this was an array
                nodes[parentLocation] += "|" + token.ToString();
            }
            else
            {
                // this was a single property
                nodes.Add(parentLocation, token.ToString());
            }
            
            return false;
        }
    }
