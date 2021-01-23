    public delegate void DoSome(object sender);
    
    public class MyClass{
          public event DoSome callbackfunc;
          
          public void DoWork(){
                // do work here 
                if(callbackfunc != null)
                         callbackfunc(something);
          }
    }
