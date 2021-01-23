    Dictionary<string, string> _refValues = new Dictionary<string, string>();
    Dictionary<string, string> _viewNames = new Dictionary<string, string>();
    fillDictionaries();
    void fillDictionaries()
    {
        _refValues.add("00","14"); //one way to add a value
        _viewNames["00"] = "Menu"; //another way to add a value
    }
    string getRefValue(string id)
    {
        return _refvalues[id]; //there may be a get method but I'm not using an IDE atm
    }
    //same function for viewNames
