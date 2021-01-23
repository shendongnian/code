    interface IExample
    {
       // method signature
       void MyMethod();
    }
    public class MyClass : IExample
    {
       // method implementation
       public void MyMethod()
       {
          ConsoleWriteline("This is my method");
       }
    }
    
    // interface pointing to instance of class
    IExample ie = new MyClass();
    ie.MyMethod();
