    public class DataGridViewEx : DataGridView
    {
        Dictionary<DataGridViewColumn, bool> dictionaryCheckBox = new Dictionary<DataGridViewColumn, bool>();
        System.Drawing.Bitmap[] bmCheckBox = new System.Drawing.Bitmap[2];
        bool executarValueChanged = true;
        public DataGridViewEx()
            : base()
        {
            #region CheckBox no header da coluna
            CheckBox chkTemp = new CheckBox();
            chkTemp.AutoSize = true;
            chkTemp.BackColor = System.Drawing.Color.Transparent;
            chkTemp.Size = new System.Drawing.Size(16, 16);
            chkTemp.UseVisualStyleBackColor = false;
            bmCheckBox[0] = new System.Drawing.Bitmap(chkTemp.Width, chkTemp.Height);
            bmCheckBox[1] = new System.Drawing.Bitmap(chkTemp.Width, chkTemp.Height);
          
            chkTemp.Checked = false;
            chkTemp.DrawToBitmap(bmCheckBox[0], new System.Drawing.Rectangle(0, 0, chkTemp.Width, chkTemp.Height));
           
            chkTemp.Checked = true;
            chkTemp.DrawToBitmap(bmCheckBox[1], new System.Drawing.Rectangle(0, 0, chkTemp.Width, chkTemp.Height));
            #endregion
        }
        public void CheckBoxHeader(DataGridViewCheckBoxColumn column, bool enabled)
        {
            if (enabled == true)
            {
                if (dictionaryCheckBox.Any(f => f.Key == column) == false)
                {
                    dictionaryCheckBox.Add(column, false);
                    this.InvalidateCell(column.HeaderCell);
                }
            }
            else
            {
                dictionaryCheckBox.Remove(column);
                this.InvalidateCell(column.HeaderCell);
            }
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            if (e.ColumnIndex >= 0 && e.RowIndex == -1 && dictionaryCheckBox.Any(f => f.Key == this.Columns[e.ColumnIndex]) == true)
            {
                Bitmap bmp = dictionaryCheckBox[this.Columns[e.ColumnIndex]] == true ? bmCheckBox[1] : bmCheckBox[0];
                Rectangle imageBounds = new Rectangle(new Point(e.CellBounds.Location.X + (e.CellBounds.Width / 2) - (bmp.Size.Width / 2), e.CellBounds.Location.Y + (e.CellBounds.Height / 2) - (bmp.Size.Height / 2)), bmp.Size);
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);
                e.Graphics.DrawImage(bmp, imageBounds);
                e.Handled = true;
            }
        }
        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnColumnHeaderMouseClick(e);
            if (dictionaryCheckBox.ContainsKey(this.Columns[e.ColumnIndex]) == true)
            {
                var header = this.Columns[e.ColumnIndex].HeaderCell;
                Bitmap img = dictionaryCheckBox[this.Columns[e.ColumnIndex]] == true ? bmCheckBox[1] : bmCheckBox[0];
                if (e.Button == System.Windows.Forms.MouseButtons.Left &&
                   e.Y >= header.ContentBounds.Y + (header.Size.Height / 2) - (img.Height / 2) &&
                   e.Y <= header.ContentBounds.Y + (header.Size.Height / 2) + (img.Height / 2) &&
                   e.X >= header.ContentBounds.X + (this.Columns[e.ColumnIndex].Width / 2) - (img.Width / 2) &&
                   e.X <= header.ContentBounds.X + (this.Columns[e.ColumnIndex].Width / 2) + (img.Width / 2))
                {
                    dictionaryCheckBox[this.Columns[e.ColumnIndex]] = !dictionaryCheckBox[this.Columns[e.ColumnIndex]];
                    this.InvalidateCell(this.Columns[e.ColumnIndex].HeaderCell);
                    executarValueChanged = false;
                    for (Int32 i = 0; i < this.Rows.Count; i++)
                    {
                        this.Rows[i].Cells[e.ColumnIndex].Value = dictionaryCheckBox[this.Columns[e.ColumnIndex]];
                        this.RefreshEdit();
                    }
                    executarValueChanged = true;
                }
            }
        }
        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            List<DataGridViewColumn> listColunas = this.Columns.Cast<DataGridViewColumn>().Where(f => f.GetType() == typeof(DataGridViewCheckBoxColumn)).ToList();
            foreach (DataGridViewColumn coluna in listColunas)
            {
                if (dictionaryCheckBox.ContainsKey(coluna) == true)
                {
                    if (dictionaryCheckBox[coluna] == true)
                    {
                        executarValueChanged = false;
                        this.Rows[e.RowIndex].Cells[coluna.Index].Value = true;
                        this.RefreshEdit();
                        executarValueChanged = true;
                    }
                }
            }
        }
        protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
        {
            base.OnRowsRemoved(e);
            List<DataGridViewColumn> listColunas = this.Columns.Cast<DataGridViewColumn>().Where(f => f.GetType() == typeof(DataGridViewCheckBoxColumn)).ToList();
            foreach (DataGridViewColumn coluna in listColunas)
            {
                if (dictionaryCheckBox.ContainsKey(coluna) == true)
                {
                    if (this.Rows.Count == 0)
                    {
                        dictionaryCheckBox[coluna] = false;
                        this.InvalidateCell(coluna.HeaderCell);
                    }
                    else
                    {
                        Int32 numeroLinhas = this.Rows.Cast<DataGridViewRow>().Where(f => Convert.ToBoolean(f.Cells[coluna.Index].Value) == true).Count();
                        if (numeroLinhas == this.Rows.Count)
                        {
                            dictionaryCheckBox[coluna] = true;
                            this.InvalidateCell(coluna.HeaderCell);
                        }
                    }
                }
            }
        }
        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            base.OnCellValueChanged(e);
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dictionaryCheckBox.ContainsKey(this.Columns[e.ColumnIndex]) == true)
                {
                    if (executarValueChanged == false)
                    {
                        return;
                    }
                    Boolean existeFalse = this.Rows.Cast<DataGridViewRow>().Any(f => Convert.ToBoolean(f.Cells[e.ColumnIndex].Value) == false);
                    if (existeFalse == true)
                    {
                        if (dictionaryCheckBox[this.Columns[e.ColumnIndex]] == true)
                        {
                            dictionaryCheckBox[this.Columns[e.ColumnIndex]] = false;
                            this.InvalidateCell(this.Columns[e.ColumnIndex].HeaderCell);
                        }
                    }
                    else
                    {
                        dictionaryCheckBox[this.Columns[e.ColumnIndex]] = true;
                        this.InvalidateCell(this.Columns[e.ColumnIndex].HeaderCell);
                    }
                }
            }
        }
        protected override void OnCurrentCellDirtyStateChanged(EventArgs e)
        {
            base.OnCurrentCellDirtyStateChanged(e);
            if (this.CurrentCell is DataGridViewCheckBoxCell)
            {
                this.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
