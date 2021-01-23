       public class GridCheckMarksSelection
    {
        public event EventHandler SelectionChanged;
        protected GridView _view;
        protected ArrayList _selection;
        private GridColumn _column;
        private RepositoryItemCheckEdit _edit;
        public GridView View
        {
            get { return _view; }
            set
            {
                if (_view == value)
                    return;
                if (_view != null)
                    Detach();
                _view = value;
                Attach();
            }
        }
        public GridColumn CheckMarkColumn { get { return _column; } }
        public int SelectedCount { get { return _selection.Count; } }
        
        public GridCheckMarksSelection()
        {
            _selection = new ArrayList();
        }
        public GridCheckMarksSelection(GridView view)
            : this()
        {
            this.View = view;
        }
        protected virtual void Attach()
        {
            if (View == null)
                return;
            _selection.Clear();
            _view = View;
            _edit = View.GridControl.RepositoryItems.Add("CheckEdit") 
                as RepositoryItemCheckEdit;
            _edit.EditValueChanged += edit_EditValueChanged;
            _column = View.Columns.Insert(0);
            _column.OptionsColumn.AllowSort = DefaultBoolean.False;
            _column.VisibleIndex = int.MinValue;
            _column.FieldName = "CheckMarkSelection";
            _column.Caption = "Mark";
            _column.OptionsColumn.ShowCaption = false;
            _column.UnboundType = UnboundColumnType.Boolean;
            _column.ColumnEdit = _edit;
            View.CustomDrawColumnHeader += View_CustomDrawColumnHeader;
            View.CustomDrawGroupRow += View_CustomDrawGroupRow;
            View.CustomUnboundColumnData += view_CustomUnboundColumnData;
            View.MouseUp += view_MouseUp;
        }
        protected virtual void Detach()
        {
            if (_view == null)
                return;
            if (_column != null)
                _column.Dispose();
            if (_edit != null)
            {
                _view.GridControl.RepositoryItems.Remove(_edit);
                _edit.Dispose();
            }
            _view.CustomDrawColumnHeader -= View_CustomDrawColumnHeader;
            _view.CustomDrawGroupRow -= View_CustomDrawGroupRow;
            _view.CustomUnboundColumnData -= view_CustomUnboundColumnData;
            _view.MouseDown -= view_MouseUp;
            _view = null;
        }
        protected virtual void OnSelectionChanged(EventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }
        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
        {
            var info = _edit.CreateViewInfo() as CheckEditViewInfo;
            var painter = _edit.CreatePainter() as CheckEditPainter;
            ControlGraphicsInfoArgs args;
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new ControlGraphicsInfoArgs(info, new GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }
        private void view_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                GridHitInfo info;
                var pt = _view.GridControl.PointToClient(Control.MousePosition);
                info = _view.CalcHitInfo(pt);
                if (info.InRow && _view.IsDataRow(info.RowHandle))
                    UpdateSelection();
                if (info.InColumn && info.Column == _column)
                {
                    if (SelectedCount == _view.DataRowCount)
                        ClearSelection();
                    else
                        SelectAll();
                }
                if (info.InRow && _view.IsGroupRow(info.RowHandle) 
                    && info.HitTest != GridHitTest.RowGroupButton)
                {
                    bool selected = IsGroupRowSelected(info.RowHandle);
                    SelectGroup(info.RowHandle, !selected);
                }
            }
        }
        private void View_CustomDrawColumnHeader
            (object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != _column)
                return;
            e.Info.InnerElements.Clear();
            e.Painter.DrawObject(e.Info);
            DrawCheckBox(e.Graphics, e.Bounds, SelectedCount == _view.DataRowCount);
            e.Handled = true;
        }
        private void View_CustomDrawGroupRow
            (object sender, RowObjectCustomDrawEventArgs e)
        {
            var info = e.Info as GridGroupRowInfo;
            info.GroupText = "         " + info.GroupText.TrimStart();
            e.Info.Paint.FillRectangle
               (e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
            e.Painter.DrawObject(e.Info);
            var r = info.ButtonBounds;
            r.Offset(r.Width * 2, 0);
            DrawCheckBox(e.Graphics, r, IsGroupRowSelected(e.RowHandle));
            e.Handled = true;
        }
        private void view_CustomUnboundColumnData
            (object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column != CheckMarkColumn)
                return;
            if (e.IsGetData)
                e.Value = IsRowSelected(View.GetRowHandle(e.ListSourceRowIndex));
            else
                SelectRow(View.GetRowHandle(e.ListSourceRowIndex), (bool)e.Value);
        }
        private void edit_EditValueChanged(object sender, EventArgs e)
        {
            _view.PostEditor();
        }
        private void SelectRow(int rowHandle, bool select, bool invalidate)
        {
            if (IsRowSelected(rowHandle) == select)
                return;
            object row = _view.GetRow(rowHandle);
            if (select)
                _selection.Add(row);
            else
                _selection.Remove(row);
            if (invalidate)
                Invalidate();
            OnSelectionChanged(EventArgs.Empty);
        }
        public object GetSelectedRow(int index)
        {
            return _selection[index];
        }
        public int GetSelectedIndex(object row)
        {
            return _selection.IndexOf(row);
        }
        public void ClearSelection()
        {
            _selection.Clear();
            View.ClearSelection();
            Invalidate();
            OnSelectionChanged(EventArgs.Empty);
        }
        private void Invalidate()
        {
            _view.CloseEditor();
            _view.BeginUpdate();
            _view.EndUpdate();
        }
        public void SelectAll()
        {
            _selection.Clear();
            var dataSource = _view.DataSource as ICollection;
            if (dataSource != null && dataSource.Count == _view.DataRowCount)
                _selection.AddRange(dataSource);  // fast
            else
                for (int i = 0; i < _view.DataRowCount; i++)  // slow
                    _selection.Add(_view.GetRow(i));
            Invalidate();
            OnSelectionChanged(EventArgs.Empty);
        }
        public void SelectGroup(int rowHandle, bool select)
        {
            if (IsGroupRowSelected(rowHandle) && select) return;
            for (int i = 0; i < _view.GetChildRowCount(rowHandle); i++)
            {
                int childRowHandle = _view.GetChildRowHandle(rowHandle, i);
                if (_view.IsGroupRow(childRowHandle))
                    SelectGroup(childRowHandle, select);
                else
                    SelectRow(childRowHandle, select, false);
            }
            Invalidate();
        }
        public void SelectRow(int rowHandle, bool select)
        {
            SelectRow(rowHandle, select, true);
        }
        public bool IsGroupRowSelected(int rowHandle)
        {
            for (int i = 0; i < _view.GetChildRowCount(rowHandle); i++)
            {
                int row = _view.GetChildRowHandle(rowHandle, i);
                if (_view.IsGroupRow(row))
                    if (!IsGroupRowSelected(row))
                        return false;
                    else
                        if (!IsRowSelected(row))
                            return false;
            }
            return true;
        }
        public bool IsRowSelected(int rowHandle)
        {
            if (_view.IsGroupRow(rowHandle))
                return IsGroupRowSelected(rowHandle);
            object row = _view.GetRow(rowHandle);
            return GetSelectedIndex(row) != -1;
        }
        public void UpdateSelection()
        {
            _selection.Clear();
            Array.ForEach(View.GetSelectedRows(), item => SelectRow(item, true));
        }
    }
