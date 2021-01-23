    using System.Drawing;
    public sealed class Cell
    {
        public bool Hover { get; set; }
        public enum CellState { Inactive, Intermediate, Active }
        public CellState State { get; private set; }
        public int Column { get; private set; }
        public int Row { get; private set; }
        public Rectangle Bounds { get; private set; }
        public Cell (int column, int row, CellState state = CellState.Inactive)
        {
            this.Column = column;
            this.Row = row;
        }
        public void SetDimensions (Rectangle bounds)
        {
            this.Bounds = bounds;
        }
        public void RotateState ()
        {
            switch (this.State)
            {
                case CellState.Active: { this.State = CellState.Inactive; break; }
                case CellState.Inactive: { this.State = CellState.Intermediate; break; }
                case CellState.Intermediate: { this.State = CellState.Active; break; }
            }
        }
    }
