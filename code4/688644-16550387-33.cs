    class TicTacToe {
        const int Length = 3;
        private bool? [][] _data;
        private bool? _winner;
    
        public TicTacToe ()
        {
            _data = Enumerable
                .Range (0, Length)
                .Select (_ => new bool? [Length])
                .ToArray ();
        }
    }
