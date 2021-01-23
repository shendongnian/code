    Dictionary<string, object> LoadINI(string fileName)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();
            string fileText = File.ReadAllText(fileName);
            string[] fileLines = fileText.Split('\r');
            if (fileLines.Length > 0)
                for (int i = 0; i < fileLines.Length; i++)
                {
                    string line = fileLines[i].Trim();
                    if (!string.IsNullOrEmpty(line))
                    {
                        int equalsLocation = line.IndexOf('=');
                        if (equalsLocation > 0)
                        {
                            string key = line.Substring(0, equalsLocation).Trim();
                            string value = line.Substring(equalsLocation + 1, line.Length - equalsLocation - 1);
                            results.Add(key, value);
                        }
                    }
                }
            return results;
        }
