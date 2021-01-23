    public class Game
    {
        public int Id { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
    public class Score
    {
        public int ScoreId { get; set; }
        public virtual  Player Player { get; set; }
        public virtual Game Game { get; set; }
        public int Score { get; set; }
    }
