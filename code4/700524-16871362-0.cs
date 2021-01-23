    // ask user for input
    string input = Console.Readline();
    int parsed;
    // parse to int, needs error checking (will throw exception when input is not a valid int)
    int.TryParse(input, out parsed);
    
    Random random = new Random();
    List<double> list = new List<double>();
    
    for(int i = 0; i < parsed; parsed++)
    {
      list.Add(random.Next(100));
    }
