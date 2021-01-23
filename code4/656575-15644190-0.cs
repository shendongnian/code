    var result = new List<string>();
    foreach(var line in lines)
    {
      var newLine = line.Replace('ý','\t');
      var count = newLine.Count(f=>f=='\t');
      if (count<4)
        for(int i=0; i<4-count; i++)
          newLine += "\t";
      result.Add(newLine);
    }
    File.WriteAllLines(output_file, result);
