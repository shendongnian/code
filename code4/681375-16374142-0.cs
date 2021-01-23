    void BtnApagar_ClickClick(object sender, EventArgs e)
    {
        // test if textbox 4 exist by counting the number of added textboxes
        if(textBoxList.Count ==4 || textBoxList.Count > 4)
        {
            // List and array are 0 based --> index 3 is the 4th textbox
            MessageBox.Show("Perfect we have " 
                            + " at least 4 boxes and the name is: " 
                            + textBoxList[3].Name);		
        }else {
            MessageBox.Show("Number of textboxes is not enough - add more");
        }
    }
