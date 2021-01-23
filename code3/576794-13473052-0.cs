    public void main()
    {    
      string test = "testing";
      ChangeVal(ref test);
      Console.WriteLine(test);
    }
    private void ChangeVal(ref string test)
    {
        test = "in child";
    }
