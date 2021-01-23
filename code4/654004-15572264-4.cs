    if (listView1.SelectedItems.Count > 0)
    {
        var confirmation = MessageBox.Show("Voulez vous vraiment supprimer les stagiaires séléctionnés?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirmation == DialogResult.Yes)
        {
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem itm = listView1.SelectedItems[i];
                listView1.Items[itm.Index].Remove();
            }
        }
    }
    else
        MessageBox.Show("aucin stagiaire selectionnes", ...);
