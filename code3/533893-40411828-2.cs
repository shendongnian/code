    private void lvTaskList_MouseLeave(object sender, EventArgs e)
        {
            Color oOriginalColor = Color.Blue; //Your original color
            //When the mouse leave the control. If a ListViewItem was highlighted then set it's original color back
            if (lvHoveredItem != null)
            {
                lvHoveredItem.BackColor = oOriginalColor ;
            }
            lvHoveredItem = null;
        }
