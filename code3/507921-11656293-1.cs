            public List<List<string>> ReadCsvTable(string path) {
                List<List<string>> table = new List<List<string>>();
                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string line in lines) {
                    table.Add(new List<string>(line.Split(',')));
                }
                return table;
            }
