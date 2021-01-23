private static void CombineMultipleFilesIntoSingleFile(string inputDirectoryPath, string inputFileNamePattern, string outputFilePath)
        {
            string[] inputFilePaths = Directory.GetFiles(inputDirectoryPath, inputFileNamePattern);
            Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);
            foreach (var inputFilePath in inputFilePaths)
            {
                using (var outputStream = File.AppendText(outputFilePath))
                {
                    // Buffer size can be passed as the second argument.
                    outputStream.WriteLine(File.ReadAllText(inputFilePath));
                    Console.WriteLine("The file {0} has been processed.", inputFilePath);
                }
            }
        }
  [1]: https://stackoverflow.com/users/490018/sergey-brunov
