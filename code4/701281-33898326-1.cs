    public partial class DraggableDataGridView : System.Windows.Forms.DataGridView {
        private Rectangle dragBoxFromMouseDown;
        protected override void OnMouseDown(MouseEventArgs e) {
            // Trap the case where the user pressed the left mouse button on an already-selected row
            // without <shift> or <control>
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left
                && Control.ModifierKeys == Keys.None
                && this.SelectedRows.Count > 0
                && this.SelectedRows.Contains(this.Rows[HitTest(e.X, e.Y).RowIndex])
                ) {
                    // User pressed the mouse button over an already-selected row without <shift> or <control> so we should 
                    // consider drag and drop. Record a rectangle around that mouse location to possibly trigger drag
                    // operation
                    Debug.WriteLine("MouseDown inside selection");
                    Size dragSize = SystemInformation.DragSize;
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            } else {
                // In other cases use the default behavior for datagridview
                Debug.WriteLine("MouseDown outside selection");
                dragBoxFromMouseDown = Rectangle.Empty;
                base.OnMouseDown(e);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e) {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {
                // If the mouse moves outside the drag limit rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.Location)) {
                    // Proceed with the drag and drop, passing in the selected rows
                    DragDropEffects dropEffect =
                            this.DoDragDrop(this.SelectedRows, DragDropEffects.Move);
                }
            }
            base.OnMouseMove(e);
        }
        public DraggableDataGridView() {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }
    }
    
