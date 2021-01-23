    public class MyGame
    {
        private int start;
        private Board board;
        public MyGame(MyGame orig)
        {
            // value types - like integers - can easily be
            // reused
            this.start = orig.start;
            // reference types must be clones seperately, you
            // must not use orig.board directly here
            this.board = new Board(orig.board);
        }
    }
    public class Board
    {
        private int count;
        public Board(Board orig)
        {
            // here we have a value type again
            this.count = orig.count;
            // here we have no reference types. if we did
            // we'd have to clone them too, as above
        }
    }
