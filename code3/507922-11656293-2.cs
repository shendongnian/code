            public List<List<string>> ReadCsvTable(string path) {
                List<List<string>> table = new List<List<string>>();
                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string line in lines) {
                    List<string> rawFields = new List<string>(line.Split(','));                
                    List<string> processedFields = new List<string>();
                    foreach(string field in rawFields){
                        Match m = Regex.Match("^\"?(^<value>.*)\"?$", line);
                        processedFields.Add(m.Groups["value"].Value);
                    }                
                    table.Add(processedFields);
                }
                return table;
            }
