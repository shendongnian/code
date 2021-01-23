    List<double> numbers = new List<double>();
    double buffer = 0;
    while (string line = reader.ReadLine() != null)
    {
          string[] tokens = line.Split(',');
          foreach (string s in tokens)
          {
              if (double.TryParse(s, out buffer))
                  numbers.Add(buffer);
          }
    }
    // to print the values with iteration
    foreach (double d in numbers)
         Console.WriteLine(d.ToString());
    // to print with LINQ
    numbers.Select(x => Console.WriteLine(x.ToString()));
