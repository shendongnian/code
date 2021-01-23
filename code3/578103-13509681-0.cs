    var writer = new StreamWriter(GetFileName(baseFolder, prefix, num));
    for (int i = 0; i < arr.Length; i++)
    {
        string line = arr[i];
        line.Replace("match", "new value");
        writer.WriteLine(line);
    }
