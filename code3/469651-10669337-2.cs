    public class ThreadA{
        public ThreadA(object[] args){
            ...
        }
        public void Run(){
            while(true)
                Thread.sleep(1000); // wait 1 second for something to happen.
                doStuff();
                if(conditionToExitReceived) // what im waiting for...
                    break;
            }
            //perform cleanup if there is any...
        }
    }
