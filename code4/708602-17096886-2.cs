        Dictionary<string, double> wordDictionary = new Dictionary<string, double>();
        using (FileStream fileStream = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    int lineCount = 0;
                    int skippedLine = 0;
                    while( !reader.EndOfStream)
                    {
                        string[] fields = reader.ReadLine().Split('\t');
                        string word = fields[0];
                        double value = 0;
                        lineCount++;
                        //this check verifies there are two elements, tries to parse the second value and checks that the word 
                        //is not already in the dictionary
                        if (fields.Count() == 2 && double.TryParse(fields[1], out value) && !wordDictionary.ContainsKey(word))
                        {
                            wordDictionary.Add(word, value);
                        }
                        else{
                            skippedLine++;
                        }
                    }
                        
                    Console.WriteLine(string.Format("Total Lines Read: {0}", lineCount));
                    Console.WriteLine(string.Format("Lines Skipped: {0}", skippedLine));
                    Console.WriteLine(string.Format("Expected Entries in Dictonary: {0}", lineCount - skippedLine));
                    Console.WriteLine(string.Format("Actual Entries in Dictionary: {0}", wordDictionary.Count()));
                    reader.Close();
                }
                fileStream.Close();
            }
