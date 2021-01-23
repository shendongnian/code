    // Creating checkbox without panel
    CheckBox checkbox = new CheckBox();
    checkbox.Size = new System.Drawing.Size(15, 15);
    checkbox.BackColor = Color.Transparent;
    
    // Reset properties
    checkbox.Padding = new Padding(0);
    checkbox.Margin = new Padding(0);
    checkbox.Text = "";
    
    // Add checkbox to datagrid cell
    myDataGrid.Controls.Add(checkbox);
    DataGridViewHeaderCell header = myDataGrid.Columns[myColumnWithCheckboxes.Index].HeaderCell;
    checkbox.Location = new Point(
        header.ContentBounds.Left + (header.ContentBounds.Right - header.ContentBounds.Left + checkbox.Size.Width) / 2,
        header.ContentBounds.Top + (header.ContentBounds.Bottom - header.ContentBounds.Top + checkbox.Size.Height) / 2
    );
