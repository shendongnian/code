    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //don't allow duplicate values in ImagePaths
        if (!ImagePaths.Contains(DropDownList2.SelectedItem.Value))
        {
            if (DropDownList2.SelectedItem.Value != "-1")
            {
                // Only add to the image paths list if it is not 'Select picture to add'
                ImagePaths.Add(DropDownList2.SelectedItem.Value);
            }
        }
        // Always put the images into the DIV
        //foreach Image selected, add to testDiv
        foreach (string s in ImagePaths)
        {
            testDiv.Controls.Add(AddImage(s));
        }
    }
