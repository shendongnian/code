    public void Bar() 
    {
         Action<int> writeToConsole = i =>  { Console.WriteLine(i); }
         Action<int> writeToSomeLogger = i => { Logger.WriteLog(i); }
         Foo(writeToConsole, 10);
         Foo(writeToSomeLogger, 100);
    }
