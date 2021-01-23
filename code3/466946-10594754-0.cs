            using (var output = File.AppendText(outputFile))
            {
                foreach (var inputFile in inputFiles)
                {
                    using (var input = File.OpenText(inputFile))
                    {
                        while (!input.EndOfStream)
                        {
                            output.WriteLine(input.ReadLine());
                        }
                    }
                }
            }
