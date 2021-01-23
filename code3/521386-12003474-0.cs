    bool stopped = false; // can make this thread safe if you want.
    
    // Assuming you have a computation in a loop.
    compouteAsynch(){
    
       for(var workItme in workItems){
         if(!stopped){
          dostuff(workItem)
         }
       }
    }
    
    void stop(){
       stopped = true; // work will not stop immediately. Only in the next iteration.
    }
