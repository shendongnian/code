    public class MouseDragFormMove
    {
        private bool _status;
        public bool AllowMouseDownDrag
        {
            get { return _status; }
            set { _status = value; }
        }
        private Form parent;
        public MouseDragFormMove(Form self)
        {
            _status = false;
            parent = self;
            parent.MouseDown += new MouseEventHandler(parent_MouseDown);
            parent.MouseUp += new MouseEventHandler(parent_MouseUp);
            parent.MouseMove += new MouseEventHandler(parent_MouseMove);
        }
        private Point MPoint;
        private bool isDragging;
        private Point touchPoint;
        private void parent_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            // Capture the point relative to the form
            touchPoint = e.Location;
        }
        private void parent_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        private void parent_MouseMove(object sender, MouseEventArgs e)
        {
            MPoint = new Point(Cursor.Position.X - touchPoint.X, Cursor.Position.Y - touchPoint.Y);
            if (isDragging && AllowMouseDownDrag && !parent.Location.Equals(MPoint))
            {
                parent.Location = MPoint;
            }
        }
    }
