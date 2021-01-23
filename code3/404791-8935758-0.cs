    public class MyClass <T> where T : myGeneric 
    { 
          public void DoSomething(T foo) 
          {
              //foo has to be of type myGeneric, or a derived type
          }
    }
