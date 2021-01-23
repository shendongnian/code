    void Test(string name, string age)
    {
      Process myProcess = new Process(); 
      myProcess.Exited += (sender, eventArgs) =>
        {
          // name and age are accessible here!!
          eventHandled = true;
          Console.WriteLine("Process exited");
        }
    
    }
