    int idToRemove = 1;
    var items = (cbx.DataSource as List<MyEntity>);
    items.RemoveAll(v => v.Id == idToRemove);
    rebindCombobox(cbx, items, "Name", "Id");
    private void rebindCombobox(ComboBox cbx, IEnumerable<Object> items, String displayMember, String valueMember)
    {
        cbx.DataSource = null;
        cbx.DisplayMember = displayMember;
        cbx.ValueMember = valueMember;
        cbx.DataSource = items;
    }
