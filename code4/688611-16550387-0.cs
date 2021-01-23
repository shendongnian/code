    class TicTacToe {
        const int Length = 3;
        private bool? [][] _data;
    
        public TicTacToe ()
        {
            // Is there a simpler way to write this?
            _data = new bool? [][Length];
           
            for (var i = 0; i < Length; i++) {
                _data = new bool? [Length];
                for (var j = 0; j < Length; j++)
                    _data [i][j] = null;
            }
        }
    }
