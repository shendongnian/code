    static void Method(int normalParam, object kwargs = null)
    {
        Dictionary<string, object> args = ObjectToDictionaryRegistry(kwargs);
        ...
    }
    Method(5, new { One = 1, Two = 2 });
