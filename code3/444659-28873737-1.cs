	     //get the item at the current mouse location.
         ListViewItem item = myListView.GetItemAt(e.X, e.Y);
         if (item != null)
         {
            using (Graphics graphics = this.myListView.CreateGraphics())
            {
               var itemTextWidth = graphics.MeasureString(item.Text, item.Font).Width;
               if (itemTextWidth > myListView.Width)
               {
                  if (!item.Equals(itemsToolTip.Tag) && !itemsToolTip.Active)
                  {
                     //Set the tooltip , tag it with the item and set it as active ... 
                  }
                  // Adjacent ' text trimmed' list view items.  
                  else if (!item.Equals(itemsToolTip.Tag))
                  {
                     //set the tooltip is none active.
                  }
               }
               else//None trimmed list view items.
               {
                  //clear the tooltip and set it as none active
               }
            }
         }
         else
         {
			//clear the tooltip and set it as none active
         }
      }
