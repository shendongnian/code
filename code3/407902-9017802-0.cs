    class ThisClass
    {
       [Import]
       public IDataService DataService {get; set;}
    
       public List<MyClass> DoSomething(string Name, string Address, string Email, ref string ErrorMessage)
       {
         //Check for empty string parameters etc now go and get some data   
         List<MyClass> Data = IDataService.GetData(Name, Address, Email); // using dependency
    
         List<MyClass> FormattedData = FormatData(Data);
         return FormattedData;
       }
    }
