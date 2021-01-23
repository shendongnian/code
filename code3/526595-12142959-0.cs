        public static void WriteDifferences(string sourcePath, string destinationPath, string differencesPath)
        {
            var sourceLines = File.ReadAllLines(sourcePath).ToList();
            var destinationLines = File.ReadAllLines(destinationPath).ToList();            
            
            // make lists equal size
            if (sourceLines.Count > destinationLines.Count)
            {
                destinationLines.AddRange(Enumerable.Range(0, sourceLines.Count - destinationLines.Count).Select(x => (string)null));
            } 
            else
            {
                sourceLines.AddRange(Enumerable.Range(0, destinationLines.Count - sourceLines.Count).Select(x => (string)null));
            }
            var differences = sourceLines.Zip(destinationLines, (source, destination) => Compare(source, destination));
            File.WriteAllLines(differencesPath, differences.Where(x => x != null));
        }
        private static string Compare(string source, string destination)
        {
            return !source.Contains(destination) || source.Contains("*") ? destination : null;
        }
