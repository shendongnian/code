    // read the file in (broken apart by lines) in to an array:
    String[] lines = File.ReadAllLines("Sales.txt");
    // Try parsing them to Double values:
    Double[] numbers = lines.Select(line => {
      Double val = 0;
      Double.TryParse(line, out val);
      return val;
    });
    // Sum then using .Sum
    Double total = lines.Sum();
