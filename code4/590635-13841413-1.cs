    public class GameTeamOverride : IAutoMappingOverride<GameTeam>
    {
        public void Override(AutoMapping<GameTeam> mapping)
        {
            mapping.CompositeId()
                   .KeyReference(id => id.Game, "GameId")
                   .KeyReference(id => id.Team, "TeamId");
        }
    }
    
    public class GameTeamRoundOverride : IAutoMappingOverride<GameTeamRound>
    {
        public void Override(AutoMapping<GameTeamRound> mapping)
        {
            mapping.CompositeId()
                   .KeyReference(id => id.GameTeam.Game, "GameId")
                   .KeyReference(id => id.GameTeam.Team, "TeamId")
                   .KeyProperty(id => id.RoundNumber, "RoundId");
        }
    }
