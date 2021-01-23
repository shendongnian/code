    //create some dictionary
    NullValueDictionary<int, string> dict = new NullValueDictionary<int, string>
    {
        {1,"one"}
    };
    //have a reference to the interface
    INullValueDictionary<int, string> idict = dict;
    string val = idict[2]; // null
    val = idict[1];        // "one"
