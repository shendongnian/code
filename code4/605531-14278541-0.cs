    public class MyClass
    {
       object myLockObject = new object();
    
       public void MyOperationCalledOnAnEvent(string data)
       {
          lock (myLockObject)
              sw.WriteLine(outLine.Data);
       } 
    
    }
