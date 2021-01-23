    foreach (DictionaryEntry member in lua.GetTable("test_data"))
    {
    
        foreach (DictionaryEntry keyval in ((LuaTable)member.Value))
        {
            Console.WriteLine(String.Format("{0}={1}", keyval.Key, keyval.Value));
        }
        Console.WriteLine("===================================");
    }
