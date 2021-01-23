    private  void button1_Click(object sender, EventArgs e)
    {
        Form2 other = new Form2();
        other.CheckedItems = listBox1.SelectedItems.OfType<string>();
        other.FormClosed += (s, args) => setSelectedListboxItems(other.CheckedItems);
        other.Show();
    }
    
    private void setSelectedListboxItems(IEnumerable<string> enumerable)
    {
        var itemsToSelect = new HashSet<string>(enumerable);
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
            listBox1.SetSelected(i , itemsToSelect.Contains(listBox1.Items[i]));
        }
    }
