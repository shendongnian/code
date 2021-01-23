    public class MyGame : ICloneable
    {
        private int start;
        private Board board;
        public object Clone()
        {
            var copy = new MyGame();
            copy.start = this.start;
            copy.board = (Board)this.board.Clone();
            return copy;
        }
    }
    public class Board : ICloneable
    {
        private int count;
        public object Clone()
        {
            var copy = new Board();
            copy.count = this.count;
            return copy;
        }
    }
