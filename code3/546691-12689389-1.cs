        public static IEnumerable<string> ReadLines(string fileName)
        {
            string line;
            using (var reader = File.OpenText(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                    yield return line;
            }
        }
