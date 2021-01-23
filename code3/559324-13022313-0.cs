            var listOfBufferedLines = ReadLineFromFile(ReadFilePath);
            var listOfLinesInBatch = new List<string>();
            foreach (var line in listOfBufferedLines)
            {
                listOfLinesInBatch.Add(line);
                if (listOfLinesInBatch.Count % 1000 == 0)
                {
                    Console.WriteLine("Writing Batch.");
                    WriteLinesToFile(listOfLinesInBatch, LoadFilePath);
                    listOfLinesInBatch.Clear();
                }
            }
            
            // writing the remaining lines
            WriteLinesToFile(listOfLinesInBatch, LoadFilePath);
