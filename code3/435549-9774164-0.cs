    void Main()
    {
     string[] temp;
     foo(out temp);
     foreach(string s in temp)
      System.Console.WriteLine(s);
    }
    
    void foo(out string[] temp)
    {
     temp = {"Hello World", "You must be updated now"};
    }
