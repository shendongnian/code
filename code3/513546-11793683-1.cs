    class Sudoku
    {
        public int[,] Cells = new int[9,9];
        ...
    }
    private Sudoku _sudoku;
    MainWindow_Loaded(...)
    {
        _sudoku = new Sudoku();
        grid.DataContext= _sudoku;
    }
