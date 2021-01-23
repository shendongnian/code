    //if (lvPhotos.SelectedIndices.Count > 0)
                if (lvPhotos.CheckedIndices.Count > 0)
                {
                    var confirmation = MessageBox.Show("Supprimer les photos séléctionnées ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmation == DialogResult.Yes)
                    {
                        // selected
                        //for (int i = lvPhotos.SelectedIndices.Count - 1; i >= 0; i--)
                        //{
                        //    lvPhotos.Items.RemoveAt(lvPhotos.SelectedIndices[i]);
                        //}
    
                        // checked
                        for (int i = lvPhotos.CheckedIndices.Count - 1; i >= 0; i--)
                        {
                            lvPhotos.Items.RemoveAt(lvPhotos.CheckedIndices[i]);
                        }
                    }
                }
