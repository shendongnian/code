        private void listView1_Leave(object sender, EventArgs e)
        {
            // Set the global int variable (gListView1LostFocusItem) to
            // the index of the selected item that just lost focus
            gListView1LostFocusItem = listView1.FocusedItem.Index;
        }
    
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // If this item is the selected item
            if (e.Item.Selected)
            {
                // If the selected item is the one that just lost the focus
                if (gListView1LostFocusItem == e.Item.Index)
                {
                    // Set the colors to whatever you want (I would suggest
                    // something less intense than the colors used for the
                    // selected item when it has focus)
                    e.Item.ForeColor = Color.Black;
                    e.Item.BackColor = Color.LightBlue;
                    
                   // Now indicate that this action does not need to be performed
                   // again (until the next time the selected item loses focus)
                    gListView1LostFocusItem = -1;
                }
                else if (listView1.Focused)  // If the selected item has focus
                {
                    // Set the colors to the normal colors for a selected item
                    e.Item.ForeColor = SystemColors.HighlightText;
                    e.Item.BackColor = SystemColors.Highlight;
                }
            }
            else
            {
                // Set the normal colors for items that are not selected
                e.Item.ForeColor = listView1.ForeColor;
                e.Item.BackColor = listView1.BackColor;
            }
        
            e.DrawBackground();
            e.DrawText();
        }
