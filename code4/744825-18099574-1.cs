    public void PrintMe(string value)
    {
       Console.WriteLine(value);
    }
    StringBuilder sb = new StringBuilder();
    PrintMe(sb); // this will not work
