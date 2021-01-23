      public class Game
      {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GameId { get; set; }
    
        [Required]
        public DateTime GameTime { get; set; }
      }
