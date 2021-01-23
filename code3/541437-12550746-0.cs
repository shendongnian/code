    public int checkFunction(string strLine)
    {
      if (!int.TryParse(line, out age))
      {
        Console.WriteLine("{0} is not an integer", line);
        strLine = Console.ReadLine();
        return checkFunction();
      }
      else
      {
        return age;
      }
    }
