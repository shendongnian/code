        string _fileName = "Highscore.txt";
        
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_fileName))
            {
                File.Create(_fileName);
                return; 
            }
            LoadHighestScore();
        }
        private void LoadHighestScore()
        {
            HighscoreBox.Items.Clear();
            var highestScore = GetHighestScore();
            HighscoreBox.Items.Add(highestScore);
        }
        private decimal GetHighestScore()
        {
            var scores = File.ReadAllLines(_fileName);
            if (scores.Length == 0)
                return 0;
            return scores.Max(score => decimal.Parse(score));
        }
