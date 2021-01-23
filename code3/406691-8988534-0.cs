    public string GetConstantValue(string key)
    {
      return _constants[key];
    }
    private Dictionary<string, string> Constants = new Dictionary<string, string>()
    {
      { "test1", "This is testvalue1;" },
      { "test2", "This is testvalue2;" },
      { "test3", "This is testvalue3;" },
      { "test4", "This is testvalue4;" },
      { "test5", "This is testvalue5;" },
    };
