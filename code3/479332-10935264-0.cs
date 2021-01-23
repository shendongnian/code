      public class CustomColumn : DataGridViewColumn {
        public CustomColumn() : base(new CustomeCell()) { }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CustomeCell)))
                {
                    throw new InvalidCastException("It should be a custom Cell");
                }
                base.CellTemplate = value;
            }
        }        
    }
    public class CustomeCell : DataGridViewCell
    {
        public CustomeCell() : base() { }
        public override Type ValueType
        {
            get
            {
                return typeof(CustomUserControl);
            }
        }
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            CustomUserControl ctrl = (CustomUserControl)value;
            Bitmap img = new Bitmap(cellBounds.Width, cellBounds.Height);
            ctrl.DrawToBitmap(img, new Rectangle(0, 0, ctrl.Width, ctrl.Height));
            graphics.DrawImage(img, cellBounds.Location);
        }
        protected override void OnClick(DataGridViewCellEventArgs e)
        {
            List<InfoObject> objs = this.DataGridView.DataSource as List<InfoObject>;
            if (objs != null) 
            {
                if (e.RowIndex >= 0 && e.RowIndex < objs.Count) {
                    CustomUserControl ctrl = objs[e.RowIndex].Ctrl;
                    // Take any action - I will just change the color for now.
                    ctrl.BackColor = Color.Red;
                    ctrl.Refresh();
                    this.DataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }    
            }
        }
    } 
