    //Only example for Player class here... NPC would be exact same implementation
    public class Player
    {
    
        public Game CurrentGame {get; set;}
    
        public Player(Game gameInstance)
        {
            CurrentGame = gameInstance;
        }
    
        //then anywhere else in your Player and NPC classes...
        public bar() //some method in your Player and NPC classes...
        {
            var pointerToNPCFromGame = this.CurrentGame.NPCProperty;
            //here you can access the game and NPC from the Player class
            //would be the exact same for NPC to access Player class
        }
    }
