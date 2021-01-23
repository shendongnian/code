        public class Options
        {
            public static string FILENAME = @"C:\Test\testfile.txt";
            public List<KeyValuePair<string, string>> OrderedKeys { get; set; }
            public Dictionary<string, KeyValuePair<string, string>> Pairs { get; set; }
            public string GetKey(string key)
            {
                return this.Pairs[key].Value;
            }
            public void SetKey(string key, string value)
            {
                if(this.Pairs.ContainsKey(key))
                {
                    KeyValuePair<string, string> pair = new KeyValuePair<string, string>(key, value);
                    this.OrderedKeys.Insert(this.OrderedKeys.IndexOf(this.Pairs[key]), pair);
                    this.Pairs[key] = pair;
                }
            }
            public Options()
            {
                LoadFile();
            }
            ~Options()
            {
                WriteFile();
            }
            private void LoadFile()
            {
                Regex regex = new Regex(@"(?<key>\S*?)\s*=\s*(?<val>\S*?)\s*\r\n");
                MatchCollection matches = regex.Matches(File.ReadAllText(FILENAME));
                this.OrderedKeys = new List<KeyValuePair<string, string>>();
                this.Pairs = new Dictionary<string, KeyValuePair<string, string>>();
                foreach (Match match in matches)
                {
                    KeyValuePair<string, string> pair = 
                        new KeyValuePair<string,string>(match.Groups["key"].Value, match.Groups["val"].Value);
                    this.OrderedKeys.Add(pair);
                    this.Pairs.Add(pair.Key, pair);
                }
            }
            private void WriteFile()
            {
                if (File.Exists(FILENAME))
                    File.Delete(FILENAME);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(FILENAME))
                {
                    foreach (KeyValuePair<string, string> pair in this.OrderedKeys)
                    {
                        file.WriteLine(pair.Key + " = " + pair.Value);
                    }
                }
            }
        }
