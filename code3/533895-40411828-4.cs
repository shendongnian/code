    private void lvTaskList_MouseMove(object sender, MouseEventArgs e)
        {
            //Set the Color you want the list Item to be when mouse is over
            Color oItemColor = Color.Lavender;
            Color oOriginalColor = Color.blue; //Your original color
            //get the Item the Mouse is currently hover
            ListViewItem lvCurrentItem = lvTaskList.GetItemAt(e.X, e.Y);
            if ((lvCurrentItem != null) && (lvCurrentItem != lvHoveredItem))
            {
                lvCurrentItem.BackColor = oItemColor;
                if(lvHoveredItem != null)
                {
                    lvHoveredItem.BackColor = oOriginalColor ;                    
                }
               
                lvHoveredItem = lvCurrentItem;
                return;
            }
            if (lvCurrentItem == null)
            {
                if (lvHoveredItem != null)
                {
                    lvHoveredItem.BackColor = oOriginalColor; 
                }
            }
        }
