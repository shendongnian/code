    var file = @"C:\temp.txt";
    var lines = System.IO.File.ReadAllLines(file);
    var buffer = new List<String>();
    for (var i = 0; i < lines.Length; i++ )
    {
        if (i % 4 == 0) { buffer.Add(""); }
        buffer[buffer.Count - 1] += lines[i] + " ";
    }
    buffer.ForEach(b => Console.WriteLine(b));
