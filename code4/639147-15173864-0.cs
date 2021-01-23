    updateToolStripMenuItem_Click(...)
    {
        using(var update = new Form3())
        {
            var firstCol = listView.SelectedItems[0].Text;
            update.OldName = listView.SelectedItems[0].SubItems[1].Text;
            update.OldEmail = listView.SelectedItems[0].SubItems[2].Text;
            update.ShowDialog();     
        } 
    }
