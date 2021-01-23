    List<double> numbers = new List<double>();
    double buffer = 0;
    while (string line = reader.ReadLine() != null)
    {
          string[] tokens = line.Split(',');
          foreach (string s in tokens)
          {
              if (double.TryParse(s, out buffer)
                  numbers.Add(buffer);
          }
    }
