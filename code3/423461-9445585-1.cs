        private void listView1_DragOver(object sender, DragEventArgs e) {
            var pos = listView1.PointToClient(new Point(e.X, e.Y));
            var hit = listView1.HitTest(pos);
            if (hit.Item != null && hit.Item.Tag != null) {
                var dragItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                copy(dragItem, (string)hit.Item.Tag);
            }
        }
