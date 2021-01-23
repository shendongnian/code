    public sealed class ClickGraph : Control
    {
        private int squareCount = 1;
        public int SquareCount
        {
            get
            {
                return squareCount;
            }
            set
            {
                squareCount = value;
                Invalidate();
            }
        }
        private int squareSize = 25;
        public int SquareSize
        {
            get
            {
                return squareSize;
            }
            set
            {
                squareSize = value;
                Invalidate();
            }
        }
        public ClickGraph()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            int perColumn = Height / squareSize;
            int totalColumns = (squareCount / perColumn) + 1;
            for (int y = 0; y <= totalColumns - 1; y++)
            {
                int itemCount = squareCount - (y * perColumn);
                if (itemCount > perColumn)
                    itemCount = perColumn;
                for (int x = 0; x <= itemCount - 1; x++)
                    e.Graphics.FillRectangle(RandomBrush, New Rectangle((column * SquareSize) + 3, (i * SquareSize) + 3, SquareSize - 2, SquareSize - 2))
            }
        }
        
    }
