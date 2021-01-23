    public class Draggable : PictureBox
    {
        Rectangle shapeBounds;
        bool isDragging;
        Point dragPoint;
        public Draggable()
        {
            InitializeComponent();
            shapeBounds = new Rectangle(10, 10, 30, 30);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (shapeBounds.Contains(e.Location))
            {
                isDragging = true;
                dragPoint = new Point(
                    e.Location.X - shapeBounds.Location.X,
                    e.Location.Y - shapeBounds.Location.Y);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDragging = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging)
            {
                Point p = new Point(
                    e.Location.X - dragPoint.X,
                    e.Location.Y - dragPoint.Y);
                shapeBounds = new Rectangle(p, shapeBounds.Size);
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Red, shapeBounds);
        }
    }
