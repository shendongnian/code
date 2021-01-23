    protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
    {
    '''''''
    ......
    
    //Add this block
     if (memberID1.SelectedIndex > 0)
                {
                    ListItem removeItem2 = memberID2.Items.FindByValue(memberID1.SelectedValue);
                    memberID2.Items.Remove(removeItem2); 
                    ListItem removeItem3 = memberID3.Items.FindByValue(memberID1.SelectedValue);
                    memberID3.Items.Remove(removeItem3);
                }
    //End of block
    }
