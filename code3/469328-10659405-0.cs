     public class TeamViewModel 
         : MvxViewModel
         , IMvxServiceConsumer<ITeamCache>
     {
         public TeamViewModel(string teamId, string playerId)
         {
             var teamCache = this.GetService<ITeamCache>();
             Player = teamCache.GetPlayer(teamId, playerId);
             if (Player == null)
             {
                 // todo - handle this error somehow!
             }
         }
         public Player Player { get; set; }
     }
