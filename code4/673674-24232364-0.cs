    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string GameName { get; set; }
        //Navigation prop
        public virtual Details GameDetails { get; set; }
    }
    public class Details
    {
       [Key]
       [ForeignKey("Game")]
       public int GameId { get; set; }
       public int RatingId { get; set; }
       public int Grade { get; set; }
       //Navigation prop
       public virtual Game Game{ get; set; }
       public virtual RatingCompany RatingCompany { get; set; }
    }
