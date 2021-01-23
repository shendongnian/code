    string selected = null;
    private void listBox1_SelectedValueChanged(object sender, EventArgs e)
    {
        ListBox lb = sender as ListBox;
        if (lb == null) { return; }
        if (lb.SelectedItem != null && lb.SelectedItem.ToString() == selected)
        {
            selected = lb.SelectedItem.ToString();
            lb.SetSelected(lb.SelectedIndex, false);
        }
        else 
        {
            selected = lb.SelectedItem == null ? null : lb.SelectedItem.ToString();
        }
    }
