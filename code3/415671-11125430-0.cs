        private void OnMouseDown(object sender, MouseEventArgs args)
        {
            if (args.Button == MouseButtons.Right)
            {
                var item = this.IndexFromPoint(args.Location);
                if (item >= 0 && this.SelectedIndices.Contains(item) == false)
                {
                    this.SelectedItems.Clear();
                    this.SelectedIndex = item;
                }
            }
        }
