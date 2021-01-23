    void Main()
    {
        var pieces= new Piece[] 
        { 
            new Piece(1), 
            new Piece(2) 
        };
        StartGame(array);
    }
    private void StartGame(Piece[] pieces)
    {
        /* Do your work*/
    }
    class Piece
    {
        public Piece(int i)
        {
            this.Value = i;
        }
        private int Value { get; set; }
    }
