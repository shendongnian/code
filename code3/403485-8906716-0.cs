    #region GridViewCheckBoxColumn
    
       
        [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.DataGridViewCheckBoxColumn))]
        public class GridViewCheckBoxColumn : DataGridViewCheckBoxColumn
        {
            #region Constructor
    
            public GridViewCheckBoxColumn()
            {
                DatagridViewCheckBoxHeaderCell datagridViewCheckBoxHeaderCell = new DatagridViewCheckBoxHeaderCell();
    
                this.HeaderCell = datagridViewCheckBoxHeaderCell;
                this.Width = 50;
    
                //this.DataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grvList_CellFormatting);
                datagridViewCheckBoxHeaderCell.OnCheckBoxClicked += new CheckBoxClickedHandler(datagridViewCheckBoxHeaderCell_OnCheckBoxClicked);
    
            }
    
            #endregion
    
            #region Methods
    
            void datagridViewCheckBoxHeaderCell_OnCheckBoxClicked(int columnIndex, bool state)
            {
                DataGridView.RefreshEdit();
    
                foreach (DataGridViewRow row in this.DataGridView.Rows)
                {
                    if (!row.Cells[columnIndex].ReadOnly)
                    {
                        row.Cells[columnIndex].Value = state;
                    }
                }
                DataGridView.RefreshEdit();
            }
    
          
    
            #endregion
        }
    
        #endregion
    
        #region DatagridViewCheckBoxHeaderCell
    
        public delegate void CheckBoxClickedHandler(int columnIndex, bool state);
        public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
        {
            bool _bChecked;
            public DataGridViewCheckBoxHeaderCellEventArgs(int columnIndex, bool bChecked)
            {
                _bChecked = bChecked;
            }
            public bool Checked
            {
                get { return _bChecked; }
            }
        }
        class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
        {
            Point checkBoxLocation;
            Size checkBoxSize;
            bool _checked = false;
            Point _cellLocation = new Point();
            System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
            public event CheckBoxClickedHandler OnCheckBoxClicked;
    
            public DatagridViewCheckBoxHeaderCell()
            {
            }
    
            protected override void Paint(System.Drawing.Graphics graphics,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                dataGridViewElementState, value,
                formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);
                Point p = new Point();
                Size s = CheckBoxRenderer.GetGlyphSize(graphics,
                System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
                p.X = cellBounds.Location.X +
                (cellBounds.Width / 2) - (s.Width / 2);
                p.Y = cellBounds.Location.Y +
                (cellBounds.Height / 2) - (s.Height / 2);
                _cellLocation = cellBounds.Location;
                checkBoxLocation = p;
                checkBoxSize = s;
                if (_checked)
                    _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.CheckedNormal;
                else
                    _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.UncheckedNormal;
                CheckBoxRenderer.DrawCheckBox
                (graphics, checkBoxLocation, _cbState);
            }
    
            protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
            {
                Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
                if (p.X >= checkBoxLocation.X && p.X <=
                checkBoxLocation.X + checkBoxSize.Width
                && p.Y >= checkBoxLocation.Y && p.Y <=
                checkBoxLocation.Y + checkBoxSize.Height)
                {
                    _checked = !_checked;
                    if (OnCheckBoxClicked != null)
                    {
                        OnCheckBoxClicked(e.ColumnIndex, _checked);
                        this.DataGridView.InvalidateCell(this);
                    }
                }
                base.OnMouseClick(e);
            }
    
        }
    
        #endregion
    
        #region ColumnSelection
    
        class DataGridViewColumnSelector
        {
            // the DataGridView to which the DataGridViewColumnSelector is attached
            private DataGridView mDataGridView = null;
            // a CheckedListBox containing the column header text and checkboxes
            private CheckedListBox mCheckedListBox;
            // a ToolStripDropDown object used to show the popup
            private ToolStripDropDown mPopup;
    
            /// <summary>
            /// The max height of the popup
            /// </summary>
            public int MaxHeight = 300;
            /// <summary>
            /// The width of the popup
            /// </summary>
            public int Width = 200;
    
            /// <summary>
            /// Gets or sets the DataGridView to which the DataGridViewColumnSelector is attached
            /// </summary>
            public DataGridView DataGridView
            {
                get { return mDataGridView; }
                set
                {
                    // If any, remove handler from current DataGridView 
                    if (mDataGridView != null) mDataGridView.CellMouseClick -= new DataGridViewCellMouseEventHandler(mDataGridView_CellMouseClick);
                    // Set the new DataGridView
                    mDataGridView = value;
                    // Attach CellMouseClick handler to DataGridView
                    if (mDataGridView != null) mDataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(mDataGridView_CellMouseClick);
                }
            }
    
            // When user right-clicks the cell origin, it clears and fill the CheckedListBox with
            // columns header text. Then it shows the popup. 
            // In this way the CheckedListBox items are always refreshed to reflect changes occurred in 
            // DataGridView columns (column additions or name changes and so on).
            void mDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right && e.RowIndex == -1 && e.ColumnIndex == 0)
                {
                    mCheckedListBox.Items.Clear();
                    foreach (DataGridViewColumn c in mDataGridView.Columns)
                    {
                        mCheckedListBox.Items.Add(c.HeaderText, c.Visible);
                    }                
                    int PreferredHeight = (mCheckedListBox.Items.Count * 16) + 7;
                    mCheckedListBox.Height = (PreferredHeight < MaxHeight) ? PreferredHeight : MaxHeight;
                    mCheckedListBox.Width = this.Width;
                    mPopup.Show(mDataGridView.PointToScreen(new Point(e.X, e.Y)));
                }
            }
    
            // The constructor creates an instance of CheckedListBox and ToolStripDropDown.
            // the CheckedListBox is hosted by ToolStripControlHost, which in turn is
            // added to ToolStripDropDown.
            public DataGridViewColumnSelector()
            {
                mCheckedListBox = new CheckedListBox();
                mCheckedListBox.CheckOnClick = true;
                mCheckedListBox.ItemCheck += new ItemCheckEventHandler(mCheckedListBox_ItemCheck);
    
                ToolStripControlHost mControlHost = new ToolStripControlHost(mCheckedListBox);
                mControlHost.Padding = Padding.Empty;
                mControlHost.Margin = Padding.Empty;
                mControlHost.AutoSize = false;
    
                mPopup = new ToolStripDropDown();
                mPopup.Padding = Padding.Empty;
                mPopup.Items.Add(mControlHost);
            }
    
            public DataGridViewColumnSelector(DataGridView dgv)
                : this()
            {
                this.DataGridView = dgv;
            }
    
            // When user checks / unchecks a checkbox, the related column visibility is 
            // switched.
            void mCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                mDataGridView.Columns[e.Index].Visible = (e.NewValue == CheckState.Checked);
            }
        }
    
        #endregion
