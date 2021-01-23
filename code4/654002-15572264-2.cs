    if (listView1.SelectedItems.Count > 0)
    {
        var confirmation = MessageBox.Show("Voulez vous vraiment supprimer les stagiaires séléctionnés?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirmation == DialogResult.Yes)
        {
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                listView1.SelectedItems[i].Remove();
            }
        }
    }
    else
        MessageBox.ShowDialog("aucin stagiaire selectionnes", ...);
