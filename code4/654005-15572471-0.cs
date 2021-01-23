                if (listView1.SelectedIndices.Count>0)
                {
                    var confirmation = MessageBox.Show("Voulez vous vraiment supprimer les stagiaires séléctionnés?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmation == DialogResult.Yes)
                    {
                        for (int i = listView1.SelectedIndices.Count-1; i >= 0; i--)
                        {
    
                            listView1.Items.RemoveAt(listView1.SelectedIndices[i]);
    
                        }
                    }
                }
                else
                    MessageBox.Show("aucin stagiaire selectionnes", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
