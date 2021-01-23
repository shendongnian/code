    var files = Directory.EnumerateFiles(path, "*.txt", SearchOption.TopDirectoryOnly);
    
    foreach (var fPath in files)
    { 
        String[] oldLines = File.ReadAllLines(fPath); // load into memory is faster when the files are not really huge
        String key = "IdNr ";
        if (oldLines.Length != 0)
        {
            IList<String> newLines = new List<String>();
            foreach (String line in oldLines)
            {
                String newLine = line;
                if (line.Contains(key))
                {
                    int numberRangeStart = line.IndexOf(key) + key.Length;
                    int numberRangeEnd = line.IndexOf(" ", numberRangeStart);
                    String numberStr = line.Substring(numberRangeStart, numberRangeEnd - numberRangeStart);
                    int number = int.Parse(numberStr);
                    String withoutZeros = number.ToString();
                    newLine = line.Replace(key + numberStr, key + withoutZeros);
                    newLines.Add(line);
                }
                newLines.Add(newLine);
            }
            File.WriteAllLines(fPath, newLines);
        }
    }
