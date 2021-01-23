    public void DoSomething(string Data)
    {
      if (String.IsNullOrWhiteSpace(Data))
        //throw new NullReferenceException();  
        throw new ArgumentException("Data");
      //Do something with Data and let it throw??
    }
