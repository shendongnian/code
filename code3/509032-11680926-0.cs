    public class Game
    {
        public Player PlayerProperty {get; set;}
        public NPC NPCProperty {get; set;}
    
        public foo() //some method to instantiate Player and NPC
        {
           PlayerProperty = new Player(this); //hand in the current game instance
           NPCProperty = new NPC(this);  //hand in the current game instance
        }
    }
