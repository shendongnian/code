    public class BasketballTeam : ITeam<BasketballPlayer>
    {
        BasketballPlayer[] players;
        // […]
    
        public void AddPlayer(BasketballPlayer player)
        {
            this.players[this.numberOfPlayers] = player;
            this.numberOfPlayers++;
        }
    
        public IAthlete[] GetAthletes()
        {
            return this.players; 
        }
    
        // or:
        // public BasketballPlayer[] GetAthletes()
        // {
        //     return this.players; 
        // }
        // […]
    }
