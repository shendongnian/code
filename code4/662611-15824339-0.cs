     private void FunctionToCall(object state)
     {
            IInterface objectIWantToPassIn= (IInterface ) state;
            // do stuff
     }
      System.Threading.ThreadPool.QueueUserWorkItem(FunctionToCall, 
                                                    objectIWantToPassIn);
