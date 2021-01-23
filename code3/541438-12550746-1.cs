    public int checkFunction()
    {
      if (!int.TryParse(line, out age))
      {
        Console.WriteLine("{0} is not an integer", line);
        line = Console.ReadLine();
        return checkFunction();
      }
      else
      {
        return age;
      }
    }
