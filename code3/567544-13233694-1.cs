    class myCounter
    {
        private readonly Form1 Board;
        public myCounter(Form1 Board)
        {
            this.Board = Board;
        }
    
        public int turn = 0;
    
    
        public void changeColor()
        {
    
            if (turn == 0)
            {
                turn = 1;
                Board.MyLabel.....
    
               //change color code here
            }
        }
    }
