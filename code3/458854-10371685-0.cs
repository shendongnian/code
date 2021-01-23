        private void listView1_DragEnter(object sender, DragEventArgs e) {
            // It has to be a ListViewItem
            if (!e.Data.GetDataPresent(typeof(ListViewItem))) return;
            var item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            // But not one from the same ListView
            if (item.ListView == listView1) return;
            // All's well, allow the drop
            e.Effect = DragDropEffects.Copy;
        }
