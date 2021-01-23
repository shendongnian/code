    public class CustomListView : ListView
    {
        //This contains the Column Index and its corresponding Rectangle in screen coordinates.
        Dictionary<int, Rectangle> columns = new Dictionary<int, Rectangle>();
        public CustomListView()
        {
            OwnerDraw = true;//This will help the OnDrawColumnHeader be called.
        }
        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawItem(e);
        }
        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawSubItem(e);
        }
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            columns[e.ColumnIndex] = RectangleToScreen(e.Bounds);
            e.DrawDefault = true;
            base.OnDrawColumnHeader(e);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x7b)//WM_CONTEXTMENU
            {
                int lp = m.LParam.ToInt32();
                int x = ((lp << 16) >> 16);
                int y = lp >> 16;
                foreach (KeyValuePair<int, Rectangle> p in columns)
                {
                    if (p.Value.Contains(new Point(x, y)))
                    {
                        //MessageBox.Show(Columns[p.Key].Text); <-- Try this to test if you want.
                        //Show your HeaderContextMenu corresponding to a Column here.
                        break;
                    }
                }                
            }
            base.WndProc(ref m);
        }
    }
