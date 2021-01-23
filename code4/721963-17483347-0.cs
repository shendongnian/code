    public class MonitoringThread : Thread{
    ...
    
    bool working = true;
    void run(){
       while(working){
          long size = Process.GetCurrentProcess().PrivateMemorySize64;
          if (size > 2000000000){
             //do anything
          }
          else {
             try{
                Thread.Sleep(1000);
             }
             catch{}
          }
       }
    }
    
    }
