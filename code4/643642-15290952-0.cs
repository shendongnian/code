    var txt = comboBox1.Text;
    
    if (!listView1.Items.ContainsKey(txt))
    {
        lvi.Text = txt;
        lvi.Name = txt; // <= this is the key
        lvi.SubItems.Add("");
        lvi.SubItems.Add("");
        lvi.SubItems.Add("");
        lvi.SubItems.Add("");
    
        listView1.Items.Add(lvi);
    }
