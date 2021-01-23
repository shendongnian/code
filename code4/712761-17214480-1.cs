        private void lstbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If ALL is selected then select all other items
            if (lstbox.SelectedIndices.Contains(0))
            {
                lstbox.ClearSelected();
                for (int i = lstbox.Items.Count-1 ; i > 0 ; i--)
                    lstbox.SetSelected(i,true);
            }
        }
