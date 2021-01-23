    while(goingOn){
       if( q.TryTake(out var){
          Process(var)
       }
       else{
          DoSomething_Usefull_OrNotUseFull_OrEvenSleep();
       }
    }
