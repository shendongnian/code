    IEnumerable<Tuple<string, string>> Flatten(this IDictionary dict)
    {
        foreach(DictionaryEntry kvp in dict)
        {
            var childDictionary = kvp.Value as IDictionary;
            if(childDictionary != null)
            {
                foreach(var tuple in childDictionary.Flatten())
                    yield return tuple;
            }
            else
                yield return Tuple.Create(kvp.Key.ToString(), kvp.Value.ToString());
        }
    }
    // Usage:
    var flatList = data.Flatten().ToList();
