    public string Test { get; set; }
    
    public string AnotherTest
    {
       get
       {
          if(_anotherTest != null || Test == null)
             return _anotherTest;
    
          int indexLiteryS = Test.IndexOf("S")
          return Test.Substring(indexLiteryS, 4);
       }
       set { _anotherTest = value; }
    }
    private string _anotherTest;
