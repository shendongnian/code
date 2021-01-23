    public class CustomListView : ListView
    {
        [DllImport("user32")]
        private static extern bool EnumChildWindows(IntPtr parentHwnd, EnumChildProc proc, object lParam);
        delegate bool EnumChildProc(IntPtr childHwnd, object lParam);
        public CustomListView()
        {
            VisibleChanged += (s, e) =>
            {
                if (Visible && headerHandle == IntPtr.Zero&&!DesignMode)
                {
                    EnumChildWindows(Handle, EnumChild, null);
                    headerProc = new HeaderProc(this);
                    headerProc.AssignHandle(headerHandle);
                }
            };
            columnPipeLefts[0] = 0;
        }      
        //Save the Handle to the Column Headers, a ListView has only child Window which is used to render Column headers  
        IntPtr headerHandle;
        //This is used use to hook into the message loop of the Column Headers
        HeaderProc headerProc;        
        private bool EnumChild(IntPtr childHwnd, object lParam)
        {
            headerHandle = childHwnd;
            return true;
        }
        //Updated code
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x101e&&hiddenColumnIndices.Contains(m.WParam.ToInt32()))
            {                
                if(m.LParam.ToInt32() > 0) hiddenColumnWidths[m.WParam.ToInt32()] = m.LParam.ToInt32();                    
                return;//Discard the message changing hidden column width so that it won't be shown again.                
            }
            base.WndProc(ref m);
        }
        //Save the column indices which are hidden
        List<int> hiddenColumnIndices = new List<int>();
        //Save the width of hidden columns
        Dictionary<int, int> hiddenColumnWidths = new Dictionary<int, int>();
        //Save the Left (X-Position) of the Pipes which separate Column Headers.
        Dictionary<int, int> columnPipeLefts = new Dictionary<int, int>();
        protected override void OnColumnWidthChanging(ColumnWidthChangingEventArgs e)
        {
            if (hiddenColumnIndices.Contains(e.ColumnIndex))
            {
                e.Cancel = true;
                e.NewWidth = 0;
            }
            base.OnColumnWidthChanging(e);
        }
        //We need to update columnPipeLefts whenever the width of any column changes
        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {            
            base.OnColumnWidthChanged(e);
            UpdateColumnPipeLefts(Columns[e.ColumnIndex].DisplayIndex + 1);
        }
        int index = -1;
        protected override void OnColumnReordered(ColumnReorderedEventArgs e)
        {
            int i = Math.Min(e.NewDisplayIndex, e.OldDisplayIndex);
            index = index != -1 ? Math.Min(i + 1, index) : i + 1;            
            base.OnColumnReordered(e);                                
        }
        //This is used to update the columnPipeLefts every reordering columns or resizing columns.
        private void UpdateColumnPipeLefts(int fromIndex)
        {
            int w = fromIndex > 0 ? columnPipeLefts[fromIndex - 1] : 0;
            for (int i = fromIndex; i < Columns.Count; i++)
            {
                w += i > 0 ? Columns.OfType<ColumnHeader>().Where(k=>k.DisplayIndex == i - 1).Single().Width : 0;
                columnPipeLefts[i] = w;
            }
        }
        //This is used to hide a column with ColumnHeader passed in
        public void HideColumn(ColumnHeader col)
        {
            if (!hiddenColumnIndices.Contains(col.Index))
            {
                if (index != -1)
                {
                    UpdateColumnPipeLefts(index);
                    index = -1;
                }
                hiddenColumnWidths[col.Index] = col.Width;//Save the current width to restore later                
                col.Width = 0;//Hide the column
                hiddenColumnIndices.Add(col.Index);
            }
        }
        //This is used to hide a column with column index passed in
        public void HideColumn(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= Columns.Count) return;
            if (!hiddenColumnIndices.Contains(columnIndex))
            {
                if (index != -1)
                {
                    UpdateColumnPipeLefts(index);
                    index = -1;
                }
                hiddenColumnWidths[columnIndex] = Columns[columnIndex].Width;//Save the current width to restore later                
                Columns[columnIndex].Width = 0;//Hide the column
                hiddenColumnIndices.Add(columnIndex);
            }
        }
        //This is used to show a column with ColumnHeader passed in
        public void ShowColumn(ColumnHeader col)
        {
            hiddenColumnIndices.Remove(col.Index);
            if(hiddenColumnWidths.ContainsKey(col.Index))
               col.Width = hiddenColumnWidths[col.Index];//Restore the Width to show the column
            hiddenColumnWidths.Remove(col.Index);
        }
        //This is used to show a column with column index passed in
        public void ShowColumn(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= Columns.Count) return;
            hiddenColumnIndices.Remove(columnIndex);
            if(hiddenColumnWidths.ContainsKey(columnIndex))
               Columns[columnIndex].Width = hiddenColumnWidths[columnIndex];//Restore the Width to show the column            
            hiddenColumnWidths.Remove(columnIndex);
        }
        //The helper class allows us to hook into the message loop of the Column Headers
        private class HeaderProc : NativeWindow
        {
            [DllImport("user32")]
            private static extern int SetCursor(IntPtr hCursor);
            public HeaderProc(CustomListView listView)
            {
                this.listView = listView;
            }
            bool mouseDown;
            CustomListView listView;
            protected override void WndProc(ref Message m)
            {                
                if (m.Msg == 0x200 && listView!=null && !mouseDown)
                {
                    int x = (m.LParam.ToInt32() << 16) >> 16;
                    if (IsSpottedOnAnyHiddenColumnPipe(x)) return;
                }
                if (m.Msg == 0x201) { 
                    mouseDown = true;
                    int x = (m.LParam.ToInt32() << 16) >> 16;
                    IsSpottedOnAnyHiddenColumnPipe(x);
                }
                if (m.Msg == 0x202) mouseDown = false;
                base.WndProc(ref m);
            }
            private bool IsSpottedOnAnyHiddenColumnPipe(int x)
            {                
                foreach (int i in listView.hiddenColumnIndices.Select(j=>listView.Columns[j].DisplayIndex))
                {
                    if (x > listView.columnPipeLefts[i] - 1 && x < listView.columnPipeLefts[i] + 15)
                    {
                        SetCursor(Cursors.Arrow.Handle);
                        return true;
                    }
                }
                return false;
            }
        }
    }
