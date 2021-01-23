        private void textBox1_PreviewDragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(TreeViewItem))) e.Effects = e.AllowedEffects;
            e.Handled = true;
        }
        private void textBox1_PreviewDrop(object sender, DragEventArgs e) {
            var item = (TreeViewItem)e.Data.GetData(typeof(TreeViewItem));
            textBox1.Text = item.Header.ToString();   // Replace this with your own code
            e.Handled = true;
        }
        private void textBox1_PreviewDragOver(object sender, DragEventArgs e) {
            e.Handled = true;
        }
