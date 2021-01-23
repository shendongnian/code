        private Point MouseDownPos;
        private void treeView1_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            MouseDownPos = e.GetPosition(treeView1);
        }
        private void treeView1_PreviewMouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Released) return;
            var pos = e.GetPosition(treeView1);
            if (Math.Abs(pos.X - MouseDownPos.X) >= SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(pos.Y - MouseDownPos.Y) >= SystemParameters.MinimumVerticalDragDistance) {
                TreeViewItem item = e.Source as TreeViewItem;
                if (item != null) DragDrop.DoDragDrop(item, item, DragDropEffects.Copy);
            }
        }
