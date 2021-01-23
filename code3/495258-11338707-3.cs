        public class Options
        {
            public static string FILENAME = @"C:\Test\testfile.txt";
            public Dictionary<string, string> Keys { get; set; }
            public string GetKey(string key)
            {
                return this.Keys[key];
            }
            public void SetKey(string key, string value)
            {
                if (!this.Keys.ContainsKey(key))
                    this.Keys.Add(key, value);
                else
                    this.Keys[key] = value;
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
                this.Keys = new Dictionary<string, string>();
                foreach (Match match in matches)
                {
                    this.Keys.Add(match.Groups["key"].Value, match.Groups["val"].Value);
                }
            }
            private void WriteFile()
            {
                if (File.Exists(FILENAME))
                    File.Delete(FILENAME);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(FILENAME))
                {
                    foreach (KeyValuePair<string, string> pair in this.Keys)
                    {
                        file.WriteLine(pair.Key + " = " + pair.Value);
                    }
                }
            }
        }
