    private TicTacToe _game = new TicTacToe ();
    private Button [][] _buttons = new Button [][3];
    
    const bool HumanPlayer = true;
    const bool AIPlayer = false;
    
    public void HandleButtonClick (object sender, EventArgs e)
    {
        // Assuming you put a Tuple with row and column in button's Tag property
        var position = (Tuple<int, int>) ((Button) sender).Tag;
        var row = position.Item1;
        var column = position.Item2;
    
        // Sanity check
        Debug.Asset (sender == _buttons [row][column]);
    
        bool won = _game.MakeMove (row, column, HumanPlayer);
    
        if (won) {
            MessageBox.Show ("You won.");
        }
    
        RefreshButtons ();
    }
    
    void RefreshButtons ()
    {
        for (var i = 0; i < 3; i++) {
            for (var j = 0; j < 3; j++) {
                var btn = _buttons [i][j];
                var cell = _game.GetCell (i, j);
    
                btn.Enabled = !cell.HasValue;
                btn.Text = cell.HasValue
                    ? (cell.Value ? "X" : "O")
                    : string.Empty;
            }
        }
    }
