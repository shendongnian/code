        private List<Score> ReadScores(string filename) {
            List<Score> scores = new List<Score>();
            using (var sr = new StreamReader(filename)) {
                string line = "";
                while (!string.IsNullOrEmpty((line = sr.ReadLine()))) {
                    int lastspace = line.LastIndexOf(' ');
                    string name = line.Substring(0, lastspace);
                    string pointstring = line.Substring(lastspace + 1, line.Length - lastspace - 1);
                    int points = 0;
                    if (!int.TryParse(pointstring, out points))
                        throw new Exception("Wrong format");
                    
                    scores.Add(new Score(name, points);
                }
            }
            return scores;
        }
        class Score {
            public string Name { get; set; }
            public int Points { get; set; }
            public Score(string name, int points) {
                this.Name = name;
                this.Points = points;
            }
        }
