    static async Task SomeWork()
    {
      using (MyStack.Push())
      {
        ...
        Console.WriteLine(MyStack.CurrentStackAsString + ": Hi!");
      }
    }
