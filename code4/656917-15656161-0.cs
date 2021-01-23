        public IEnumerable<string> ReadLine(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                string line;
                while((line = streamReader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
