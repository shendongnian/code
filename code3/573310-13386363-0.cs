    IEnumerable<int> query = Enumerable.Empty<int>();
    int myNum = 0;
    try
    {
      query = Enumerable.Range(1, 100).Where(i => (i/myNum) > 1);
    }
    catch
    {
      Console.WriteLine("I caught divide by zero"); //does not run
    }
    
    foreach(int i in query) //divide by zero exception thrown
    {
      //..
    }
