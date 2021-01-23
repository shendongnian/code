    public IEnumerable<TestClass> GetTests(List<TestClass> tests)
    {
       foreach(var v in tests){
          if(v.ModulePosition == 1 && v.TopBotData == 2)
             yield return v;
       }
    }
