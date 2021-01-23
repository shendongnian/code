    public int Count(List<TestClass> tests)
    {
       int counter=0; 
       foreach(var v in tests){
          if(v.ModulePosition == 1 && v.topBotData == 2)
             counter++;
       }
        return counter;
    }
