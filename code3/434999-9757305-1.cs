    public static class TextReaderExtension
    {
        public static IEnumerable<string> AsEnumerable(this TextReader reader)
        {
            string line;
            while ((line=reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }  
