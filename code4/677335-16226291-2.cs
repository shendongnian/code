    using System.IO;
    
    string[] csvFile = File.ReadAllLines(pathToCsv);
    foreach (string line in csvFile)
    {
        string[] fields = line.Split(',');
        Console.WriteLine("This line was parsed as:\n{0},{1}",
                fields[0], fields[1]);
    }
