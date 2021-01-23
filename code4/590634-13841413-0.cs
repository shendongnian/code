    public class Game:IKeyed<Guid>
    {
        public virtual Guid Id { get; set; }
        //properties
    }
    
    public class Team : IKeyed<Guid>
    {
        public virtual Guid Id { get; set; }
        //Other properties
    
        public virtual IList<GameTeam> GameTeams { get; set; }
    }
    
    public class GameTeam:IKeyed<GameTeamId>
    {
        public virtual Game Game { get; set; }
        public virtual Team Team { get; set; }
        public virtual int CurrentRound { get; set; }
        public virtual IList<GameTeamRound> Rounds { get; set; }
    }
    
    public class GameTeamRound : IKeyed<GameTeamRoundId>
    {
        public virtual GameTeam GameTeam { get; set; }
        public virtual int RoundNumber { get; set; }
        //Properties
    
        public virtual IList<TeamRoundDecision> Decisions { get; set; }
    }
    
