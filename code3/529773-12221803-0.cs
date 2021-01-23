    int i;
    if (Int32.TryParse("blah", out i))
    {
      Console.WriteLine("Valid Integer");
    }
    else
    {
      Console.WriteLine("Invalid input");
    }
