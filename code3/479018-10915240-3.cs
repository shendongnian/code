    using System;
    
    namespace MyInterfaceExample
    {
        public interface IMyLogInterface
        {
            //I want to have a especific method that I'll use in MyLogClass
            void WriteLog();       
        }
    
        public class MyClass : IMyLogInterface
        {
    
            public void WriteLog()
            {
                Console.Write("MyClass was Logged");
            }
        }
    
        public class MyOtherClass : IMyLogInterface
        {
    
            public void WriteLog()
            {
                Console.Write("MyOtherClass was Logged");
                Console.Write("And I Logged it different, than MyClass");
            }
        }
    
        public class MyLogClass
        {
            //I created a WriteLog method where I can pass as parameter any object that implement IMyLogInterface.
            public static void WriteLog(IMyLogInterface myLogObject)
            {
                myLogObject.WriteLog(); //So I can use WriteLog here.
            }
        }
    
        public class MyMainClass
        {
            public void DoSomething()
            {
                MyClass aClass = new MyClass();
                MyOtherClass otherClass = new MyOtherClass();
    
                MyLogClass.WriteLog(aClass);//MyClass can log, and have his own implementation
                MyLogClass.WriteLog(otherClass); //As MyOtherClass also have his own implementation on how to log.
            }
        }
    }
