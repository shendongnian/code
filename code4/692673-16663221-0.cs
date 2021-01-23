    bool newTagCreated = false;
    
    private void tbTag_SelectionChangeCommitted(object sender, EventArgs e)
    {
    
        TagRecord tag = tbTag.SelectedItem as TagRecord;
        TagRecord newtag = null;
    
        if (!newTagCreated)
        {
          newtag = new TagRecord(tag.TagData, tag.TagName); //here we change what is going to be displayed
    
          tbTag.Items.Insert(0, newtag);
          newTagCreated = true;
        }
        else
        {
          newtag = tbTag.Items[0] as TagRecord;
          newtag.TagName = tag.TagData;
        }
    
        tbTag.SelectedIndex = 0;
    }
