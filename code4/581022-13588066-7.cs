    public class GameViewModel
    {
        // These should be full properties w/ property change notification
        // but leaving that out for simplicity right now
        public int Height;
        public int Width;
        public ObservableCollection<CellModel> Cells;
    }
    
    public class CellModel
    {
        // Same thing, full properties w/ property change notification
        public int ColumnIndex;
        public int RowIndex;
        public bool IsVisible;
        public bool IsMine;
        public int NumberAdjacentMines;
    }
