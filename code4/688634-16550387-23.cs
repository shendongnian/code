    class TicTacToe {
        const int Length = 3;
        private bool? [][] _data;
        private bool? _winner;
    
        public TicTacToe ()
        {
            _data = Enumerable.Repeat (
                Enumerable.Repeat<bool?> (null, Length).ToArray (),
                Length
            ).ToArray ();
        }
    }
