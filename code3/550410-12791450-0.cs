       class Program{
       delegate void MethodsDelegate(string Message);
       static void Main(string[] args){
       MethodsDelegate method = delegate(string Message){
       Console.WriteLine(Message);
        };
       //---call the delegated method---
     method("Using anonymous method.");
     Console.ReadLine();
      }
    }
