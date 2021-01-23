    public enum FileSystemElement
    {
        FirstDirectory,
        FirstSecondDirectory,
        FirstSecondThirdFileA,
        FirstSecondFourthFileB
    }
    public class FileSystemMapper
    {
        private readonly string _rootDirectory;
        private readonly Dictionary<FileSystemElement, string> _fileElements;
        public FileSystemMapper(string rootDirectory, string fileName)
        {
            _rootDirectory = rootDirectory;
            string[] lines = File.ReadAllLines(fileName);
            _fileElements = lines.Select(ParsePair).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        public string GetPath(FileSystemElement element)
        {
            string relativePath;
            if (!_fileElements.TryGetValue(element, out relativePath))
            {
                throw new InvalidOperationException("Element not found");
            }
            string resultPath = Path.Combine(_rootDirectory, relativePath);
            return resultPath;
        }
        private static KeyValuePair<FileSystemElement, string> ParsePair(string line)
        {
            const string separator = "|";
            // File element alias | Path
            if (string.IsNullOrEmpty(line))
                throw new ArgumentException("Null or empty line", "line");                
            string[] components = line.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (components.Length != 2)
                throw new ArgumentException("Line has invalid format", "line");
            FileSystemElement element;
            bool parseResult = FileSystemElement.TryParse(components[0], out element);
            if (!parseResult)
                throw new ArgumentException("Invalid element name", "line");
            string path = components[1]; // for clarity
            return new KeyValuePair<FileSystemElement, string>(element, path);
        }
