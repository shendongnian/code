            int[] indicies = new int[listViewCat.SelectedIndices.Count];
            listViewCat.SelectedIndices.CopyTo(indicies, 0);
            foreach(ListViewItem item in listViewCat.SelectedItems){
                listViewCat.Items.Remove(item);
                G.Categories.Remove(item.Text);
            }
            int k = 0;
            foreach(int i in indicies)
                listViewCat.Items[i+(k--)].Selected = true;
            listViewCat.Select();
