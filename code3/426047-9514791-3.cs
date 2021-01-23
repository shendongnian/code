    double d = 0;
    Boolean success = double.TryParse(splitline[8], out d);
    if(success)
      Console.WriteLine("Conversion successful!");
    else
      Console.WriteLine("Damnit.");
