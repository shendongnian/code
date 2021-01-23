    async Task<int> LongTask1() { 
      ...
      return 0; 
    }
    async Task<int> LongTask2() { 
      ...
      return 1; 
    }
    ...
    {
       Task<int> t1 = LongTask1();
       Task<int> t2 = LongTask2();
       await Task.WhenAll(t1,t2);
       //now we have t1.Result and t2.Result
    }
