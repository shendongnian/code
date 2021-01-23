    async void LongTask1() { ... }
    async void LongTask2() { ... }
    ...
    {
       Task t1 = LongTask1();
       Task t2 = LongTask2();
       await Task.WhenAll(t1,t2);
       //now we have t1.Result and t2.Result
    }
