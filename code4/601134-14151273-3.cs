    //create some dictionary
    NullValueDictionary<int, string> dict = new NullValueDictionary<int, string>
    {
        {1,"one"}
    };
    //have a reference to the interface
    INullValueDictionary<int, string> idict = dict;
    try
    {
        //this throws an exception, as the base class implementation is utilized
        Console.WriteLine(dict[2] ?? "null");
    }
    catch { }
    //this prints null, as the explicit interface implementation 
    //in the derived class is used
    Console.WriteLine(idict[2] ?? "null");
