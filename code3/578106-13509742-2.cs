    using (var input = File.OpenText("input.txt"))
    using (var output = new StreamWriter("output.txt")) {
      string line;
      while (null != (line = input.ReadLine())) {
         // optionally modify line.
         output.WriteLine(line);
      }
    }
