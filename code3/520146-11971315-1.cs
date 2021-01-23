        private void BindingSource_ListChanged(object sender, ListChangedEventArgs e) {
            this.countLabel.Text = string.Format("Count={0}", this.bindingSource.Count);
            this.columnsToolStripButton.DropDownItems.Clear();
            this.columnsToolStripButton.DropDownItems.AddRange(
                (from c in this.dataGrid.Columns.Cast<DataGridViewColumn>()
                 select new Func<ToolStripMenuItem, ToolStripMenuItem>(
                     i => {
                         i.CheckedChanged += (o1, e2) => this.dataGrid.Columns[i.Text].Visible = i.Checked;
                         return i;
                     })(
                     new ToolStripMenuItem {
                         Checked = true,
                         CheckOnClick = true,
                         Text = c.HeaderText
                     })).ToArray());
        }
