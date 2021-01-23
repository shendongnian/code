    // One line to read them all
    var lines = Console.In.ReadToEnd().Split(new[]{Environment.NewLine}, StringSplitOptions.None);
    // ...do something with them...
    Console.WriteLine(lines.Length + " lines:");
    foreach (var line in lines) Console.WriteLine(line);
