    private void MouseDown(object sender, MouseEventArgs e)
    {
        ListBox l = (ListBox) sender;
        if (e.Button == MouseButtons.Right)
        {
            l.SelectedIndex = l.IndexFromPoint(e.Location);
            if (l.SelectedIndex != -1)
            {
                if (l.Name == "listBox1")
                {
                    listboxContextMenu.Items.Clear();
                    listboxContextMenu.Items.Add("Edit");
                    listboxContextMenu.Items.Add("Add Items");
                }
                else if(l.Name = "listBox2")//etc
            }
        }
    }
