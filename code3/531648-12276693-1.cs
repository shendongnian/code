    public class MyClass{
         static int count;
         static object _lock = new object();
         public MyClass(){
             lock(_lock){
                 count++;
             }
         }
         ~MyClass(){
             lock(_lock){
                 count--;
             }
         }
    }
