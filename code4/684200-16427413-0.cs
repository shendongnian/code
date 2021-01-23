        private IEnumerable<string> GetWellFormedData(Stream s)
        {
            using (var reader = new StreamReader(s))
            {
                while (!reader.EndOfStream)
                {
                    var nextLine = reader.ReadLine();
                    if (nextLine.Length > 50)
                    {
                        // break the line into 50-chars fragments and yield return fragments
                    }
                    else
                        yield return nextLine;
                }
            }
        }
