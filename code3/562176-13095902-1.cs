    public partial class Game
    {
        public class Player
        {
            public class PositionClass
            {
                public float setPos(float X, float Y, float Z)
                {
                    //this code not included
                }
            }
            public PositionClass Position {get; set;}
            public Player() {
                Position = new PositionClass();
            }
        }
    }
