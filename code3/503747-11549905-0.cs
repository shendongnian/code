    List<string> inputLines = new List<string>();
    // Loop here getting lines
    string line = Console.ReadLine();
    inputLines.Add(line);
    // When done:
    File.WriteAllLines(@"C:\SomePath\MyFile.txt", inputLines.ToArray());
