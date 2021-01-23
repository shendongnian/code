    public class FootballGame
    {
        [Key]
        public Guid id_FootballGame { get; set; }
    
        public Guid? FK_id_FootballGame { get; set; }
        [ForeignKey("FK_id_FootballGame")]
        public virtual FootballGame PreviousFootballGame { get; set; }
    
        public Guid id_FootballTeam_owner { get; set; }
        [ForeignKey("id_FootballTeam_owner")]
        public virtual FootballTeam FootballTeamOwner { get; set; }
    
        public Guid id_FootballTeam_guest { get; set; }
        [ForeignKey("id_FootballTeam_guest")]
        public virtual FootballTeam FootballTeamGuest { get; set; }
    }
