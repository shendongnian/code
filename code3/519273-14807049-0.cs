    protected object DictionaryFunction()
    {
        Dictionary<int,YourObjectName> YourDictionaryObjectName=new Dictionary<int,YourObjectName>();
        ...
        ...
        return YourDictionaryObjectName;
    }
    protected MyFunction()
    {
        Dictionary<int,YourObjectName> MyDictionary=(Dictionary<int,YourObjectName>)DictionaryFunction();
    }
