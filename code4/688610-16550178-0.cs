    public class Game
    {
        // These will have null for unselected, true for circle, false for cross, or something like that
        public bool?[][] SquareStates = new bool?[3][3];
        // Maybe a property to show a game is in progress
        public bool GameInProgress = false;
        // Maybe a function to restart game
        public void Restart() { ... }
        // And maybe a function to check for a winner
        public string CheckWinner() { ... }
        // Maybe another function to make AI make its next move
        // and updates SquareStates.
        public void AINextMove(out int row, out int column) { ... }
    }
