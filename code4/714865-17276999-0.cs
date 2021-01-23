    [HttpPost]
    public ActionResult Test(FormCollection collection)
    {
        dynamic expando = new ExpandoObject();
        var dictionary = (IDictionary<string, object>) expando;
        foreach (var item in collection.AllKeys.ToDictionary(key => key, value => collection[value]))
        {
            dictionary.Add(item.Key, item.Value);
        }
        // your expando will be populated here ...
        // do awesomeness
    }
