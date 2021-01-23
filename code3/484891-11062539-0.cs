    class Highscore
    {
        public String Name { get; set; }
        public int Position { get; set; }
        public int Score { get; set; }
        public Highscore(String data)
        {
            var d = data.Split(' ');
            if (String.IsNullOrEmpty(data) || d.Length < 2)
                throw new ArgumentException("Invalid high score string", "data");
            
            this.Name = d[0];
            int num;
            if (int.TryParse(d[1], out num))
            {
                this.Score = num;
            }
            else
            {
                throw new ArgumentException("Invalid score", "data");
            }
        }
        public override string ToString()
        {
            return String.Format("{0}. {1}: {2}", this.Position, this.Name, this.Score);
        }
    }
