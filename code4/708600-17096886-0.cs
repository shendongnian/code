        Dictionary<string, double> wordDictionary = new Dictionary<string, double>();
        using (FileStream fileStream = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while( !reader.EndOfStream)
                    {
                        string[] fields = reader.ReadLine().Split('\t');
                        string word = fields[0];
                        double value = 0;
                        double.TryParse(fields[1], out value);
                        if (!wordDictionary.ContainsKey(word))
                        {
                            wordDictionary.Add(word, value);
                        }
                    }
                    reader.Close();
                }
                fileStream.Close();
            }
