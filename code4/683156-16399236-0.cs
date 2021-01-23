        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
            e.DrawDefault = true;
        }
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e) {
            e.DrawBackground();
            e.DrawText();
            if ((e.State & ListViewItemStates.Selected) == ListViewItemStates.Selected) {
                var bounds = e.Bounds;
                bounds.Inflate(-1, -1);
                ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
            }
        }
        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
            e.DrawBackground();
            e.DrawText();
            if ((e.ItemState & ListViewItemStates.Selected) == ListViewItemStates.Selected) {
                var bounds = e.Bounds;
                bounds.Inflate(-1, -1);
                ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
            }
        }
