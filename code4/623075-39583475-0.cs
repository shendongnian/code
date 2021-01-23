    class DummyItem {
            public string text;
            public int index;
            public override string ToString() {
            return text;
        }
    }
    public void build_dummy() {
        listbox_dummy.Items.Clear();
        for (int i = 0; i < listbox_origin.Items.Count; i++) {
            // replace with your own judgement
            if (! should_hide(listbox_origin.Items[i])) {
                DummyItem item = new DummyItem();
                item.text = listbox_origin.Items[i].ToString();
                item.index = i;
                listbox_dummy.Items.Add(item);
            }
        }
    }
    private void listbox_dummy_SelectedIndexChanged(object sender, EventArgs e) {
        var item = (DummyItem) listbox_dummy.SelectedItem;
        var index = item.index;
        listbox_origin.SelectedIndex = index;
    }
