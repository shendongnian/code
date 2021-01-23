    class TicTacToe {
        const int Length = 3;
        private bool? [][] _data;
        private bool? _winner;
    
        public TicTacToe ()
        {
            bool? emptyCell = null;
            var emptyRow = Enumerable.Repeat (emptyCell, Length).ToArray ();
            _data = Enumerable.Repeat (emptyRow, Length).ToArray ();
        }
    }
