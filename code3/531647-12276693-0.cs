    public class MyClass{
         static int count;
         static Object lock = new Object();
         public MyClass(){
             synchronized(lock){
                 count++;
             }
         }
         protected void finalize(){
             synchronized(lock){
                 count--;
             }
         }
    }
