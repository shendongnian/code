    dynamic parsedObject = JsonConvert.DeserializeObject("{ test: { inner: \"text-value\" } }");
    foreach (dynamic entry in parsedObject)
    {
        string name = entry.Name; // "test"
        dynamic value = entry.Value; // { inner: "text-value" }
    }
