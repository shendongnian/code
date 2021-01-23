         protected void YourRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
          {
               if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
                {
                   Image ImageID= e.Item.FindControl("ImageID") as Image;
                  // now play with your ImageID control..
                }
           }
