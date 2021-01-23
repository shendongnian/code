    private void SetUpCombo(CellEditEventArgs e, 
                            object ComboItems, string DisplayMember,
                            object DataSource, string PropertyName,
                            EventHandler evt)
    {
        ComboBox cb = new ComboBox();
        cb.Bounds = e.CellBounds;
        cb.DropDownStyle = ComboBoxStyle.DropDownList;
        cb.DataSource = ComboItems;
        cb.DisplayMember = DisplayMember;
        cb.DataBindings.Add("SelectedItem", DataSource, PropertyName,
                                false, DataSourceUpdateMode.Never);
        e.Control = cb;
        cb.SelectedIndexChanged += CurrentEH = evt;
    }
