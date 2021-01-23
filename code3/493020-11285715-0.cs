    static IEnumerable<string> GetWordsFromFile(StreamReader _streamReader)
    {
        while (!_streamReader.EndOfStream)
        {
            yield return _streamReader.ReadLine();
        }
    }
    static void Main(string[] args)
    {
        using (var _streamReader1 = new StreamReader("file1.txt"))
        {
            using (var _streamReader2 = new StreamReader("file2.txt"))
            {
                var words = GetWordsFromFile(_streamReader1)
                    .Except(GetWordsFromFile(_streamReader2));
            }
        }
    }
