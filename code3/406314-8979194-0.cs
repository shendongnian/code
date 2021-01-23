    private void listViewComplex_CellEditStarting(object sender, CellEditEventArgs e)
    {
        // Ignore edit events for other columns
        if (e.Column != this.columnThatYouWantToEdit)
            return;
        ComboBox cb = new ComboBox();
        cb.Bounds = e.CellBounds;
        cb.Font = ((ObjectListView)sender).Font;
        cb.DropDownStyle = ComboBoxStyle.DropDownList;
        cb.Items.AddRange(new String[] { "Single", "Married", "Divorced" });
        cb.SelectedIndex = 0; // should select the entry that reflects the current value
        e.Control = cb;
    }
