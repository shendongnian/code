    static void FixedToCsv(string sourceFile)
    {
        if (sourceFile == null)
        {
            // Throw exception
        }
        var dir = Path.GetDirectory(sourceFile)
        var destFile = string.Format(
            "{0}{1}",
            Path.GetFileNameWithoutExtension(sourceFile),
            ".csv");
        if (dir != null)
        {
            destFile = Path.Combine(dir, destFile);
        }
        if (File.Exists(destFile))
        {
            // Throw Exception
        }
        var blocks = new List<KeyValuePair<int, int>>();
        using (var output = File.OpenWrite(destFile))
        {
            using (var input = File.OpenText(sourceFile))
            {
                var outputLine = new StringBuilder();
                // Make header
                var header = input.ReadLine();
                if (header == null)
                {
                    return;
                }
                var even = false;
                var lastc = header.First();
                var counter = 0;
                var blockCounter = 0;
                foreach(var c in header)
                {
                    counter++;
                    if (c == lastc)
                    {
                        blockCounter++;
                    }
                    else
                    {
                        blocks.Add(new KeyValuePair<int, int>(
                            counter - blockCounter - 1,
                            blockCounter));
                        blockCounter = 1;
                        outputLine.Append(',');
                        even = !even;
                    }
                    outputLine.Append(even ? '1' : '0');
                    lastc = c;
                }
 
                blocks.Add(new KeyValuePair<int, int>(
                    counter - blockCounter,
                    blockCounter));
                outputLine.AppendLine();
                var lineBytes = Encoding.UTF.GetBytes(outputLine.ToString());
                outputLine.Clear();
                output.Write(lineBytes, 0, lineBytes.Length);
                // Process Body
                var inputLine = input.ReadLine();
                while (inputLine != null)
                {
                    foreach(var block in block.Select(b =>
                        inputLine.Substring(b.Key, b.Value)))
                    {
                        var sanitisedBlock = block;
                        if (block.Contains(',') || block.Contains('"'))
                        {
                            santitisedBlock = string.Format(
                                "\"{0}\"",
                                block.Replace("\"", "\"\""));
                        }
                       outputLine.Append(sanitisedBlock);
                       outputLine.Append(',');
                    }
                    outputLine.Remove(outputLine.Length - 1, 1);
                    outputLine.AppendLine();
                    lineBytes = Encoding.UTF8.GetBytes(outputLne.ToString());
                    outputLine.Clear();
                    output.Write(lineBytes, 0, lineBytes.Length);
                    inputLine = input.ReadLine();
                }
            }
        }
    }
