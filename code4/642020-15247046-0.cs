    lock(myCounter)
    { 
      if(DateTime.Now.Date != lastDateCounterWasReset)
      {
         lastDateCounterWasReset = DateTime.Now.Date;
         myCounter = 0;
      }
      myCounter++;
    }
