        private CheckBox ColumnCheckbox(DataGridView dataGridView)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Size = new Size(15, 15);
            checkBox.BackColor = Color.Transparent;
            // Reset properties
            checkBox.Padding = new Padding(0);
            checkBox.Margin = new Padding(0);
            checkBox.Text = "";
            // Add checkbox to datagrid cell
            dataGridView.Controls.Add(checkBox);
            DataGridViewHeaderCell header = dataGridView.Columns[0].HeaderCell;
            checkBox.Location = new Point(
                (header.ContentBounds.Left +
                 (header.ContentBounds.Right - header.ContentBounds.Left + checkBox.Size.Width)
                 /2) - 2,
                (header.ContentBounds.Top +
                 (header.ContentBounds.Bottom - header.ContentBounds.Top + checkBox.Size.Height)
                 /2) - 2);
            return checkBox;
        }
