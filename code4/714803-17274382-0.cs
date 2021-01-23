    var filename = "test.txt";
    var lines = System.IO.File.ReadAllLines(filename);
    System.IO.File.WriteAllLines(
        filename, 
        lines.Skip(1).Take(lines.Length - 2)
    );
