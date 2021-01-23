    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {            
        if (e.Button == MouseButtons.Right)
        {
            if (listView1.FocusedItem.Bounds.Contains(e.Location))
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        } 
    }
