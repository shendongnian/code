    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //don't allow duplicate values in ImagePaths
        if (!ImagePaths.Contains(DropDownList2.SelectedItem.Value))
        {
            if (DropDownList2.SelectedItem.Value != "-1")
            {
                ImagePaths.Add(DropDownList2.SelectedItem.Value);
                //foreach Image selected, add to testDiv
                foreach (string s in ImagePaths)
                {
                    testDiv.Controls.Add(AddImage(s));
                }
            }
        }
    }
