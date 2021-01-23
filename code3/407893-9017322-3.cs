    public List<MyClass> DoSomething(string Name, string Address,
                  string Email, ref string ErrorMessage, IDataProvider provider)
    {
      //Check for empty string parameters etc now go and get some data   
      List<MyClass> Data = provider.GetData(Name, Address, Email);
        
      List<MyClass> FormattedData = FormatData(Data);
      return FormattedData;
    }
    
