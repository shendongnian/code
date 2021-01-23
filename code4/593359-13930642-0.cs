    public class Test 
    { 
    
    private string _test;
    
    public Test(string Test)
    {
        this.Test = "test";
        // vs. 
        Test = "test";
    
        // and
        this._test = "test";
        // vs. 
        _test = "test";
    }
    
      public string Test { get; set; }
    }
