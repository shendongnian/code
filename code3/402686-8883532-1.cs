    // Input
    List<String> data = File.ReadAllLines(pfad + datei)
        .Concat(File.ReadAllLines(pfad2 + datei2))
        .Distinct().ToList();
    // Processing
    data.Sort(); 
    // Output
    data.ForEach(Console.WriteLine); 
    File.WriteAllLines(speichern, data);
