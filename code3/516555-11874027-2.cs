    private void listBox1_MouseMove(object sender, MouseEventArgs e) {
        string caption = "";
    
        int index = listBox1.IndexFromPoint(e.Location);
        if ((index >= 0) && (index < listBox1.Items.Count)) {
            caption = ((FileListBoxItem)listBox1.Items[index]).FileFullname;
        }
        toolTip1.SetToolTip(listBox1, caption);
    }
