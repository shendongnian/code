    using System.Drawing;
    public class Grid
    {
        public Cell [,] Cells { get; private set; }
        public Size Size { get; private set; }
        public Rectangle Bounds { get; private set; }
        public Grid (Size gridSize)
        {
            this.Size = gridSize;
            this.Cells = new Cell [this.Size.Width, this.Size.Height];
            for (int r=0; r < this.Size.Height; r++)
            {
                for (int c=0; c < this.Size.Width; c++)
                {
                    this.Cells [c, r] = new Cell(c, r);
                }
            }
        }
        public void SetDimensions (Rectangle bounds)
        {
            Size size;
            this.Bounds = bounds;
            size = new Size((int) (((float) bounds.Width) / ((float) this.Size.Width)), (int) (((float) bounds.Height) / ((float) this.Size.Height)));
            for (int r=0; r < this.Size.Height; r++)
            {
                for (int c=0; c < this.Size.Width; c++)
                {
                    this.Cells [c, r].SetDimensions(new Rectangle(bounds.Left + (size.Width * c), bounds.Top + (size.Height * r), size.Width, size.Height));
                }
            }
        }
    }
