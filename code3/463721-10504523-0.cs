     public MyConsole
     {
         // expose the neede methods:
         public void WriteLine(string text)
         {
             Console.WriteLine(text.Replace(...)); // filter out the special chars
         }
     }
