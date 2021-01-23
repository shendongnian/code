    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var game = new Game();
            game.StartGame();
        }
    }
    
    public class Game
    {
        Piece black1, black2, black3,
        black4, black5, black6, black7, 
        black8, black9, black10, black11,
        black12, white1, white2, white3,
        white4, white5, white6, white7,
        white8, white9, white10, white11, white12;
        public struct CellReference
        {
            public int CellsNorth;
        
            public int CellsEast;
        }
        
        public class Piece
        {
            public CellReference Location
            public bool isBlack;
            public bool isKing;
        }
        
        public StartGame()
        {
            // play game logic here
        }
    }
