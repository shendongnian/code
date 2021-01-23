        // create my data object
        SerializableClassX SerializableObj = new SerializableClassX(param);
        // this will call the DictionaryX.set and convert the '
        // new Dictionary into SerializableList
        SerializableObj.DictionaryX = new Dictionary<string, int>
        {
            {"Key1", 1},
            {"Key2", 2},
        };
