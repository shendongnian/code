    int numberOfTimesUsed = 0;
    myObject.Func = (x) => 
    { 
       numberOfTimesUsed++;
       Assert.IsNotNull(x); // checks if x passed was not null
    };
    
    ...
     
    Assert.AreEqual(2, numberOfTimesUsed); // checks if called twice
