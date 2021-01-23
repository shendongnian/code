    public class Test
    {
     private string _test;
     public Test(string Test,string _test)
     {
        this.Test = "test";//this refers invoking object Test i.e class varaible
        // vs. 
        Test = "test";//this refer method passed Test param
        // and
        this._test = "test";//this refers invoking object Test i.e class varaible
        // vs. 
        _test = "test";//this refer method passed Test param
    }
      public string Test { get; set; }
    }
