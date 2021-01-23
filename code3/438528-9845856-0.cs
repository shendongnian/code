    public MyModel
    {
      public string Value1 {get;set;}
      public string Value2 {get;set;}
      public string Value3 {get;set;}
    }
    
    public ActionResult MyActionMethod(MyModel model)
    { 
       //oooh model is populated here
    }
