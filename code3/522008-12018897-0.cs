    int PreviousIndex = -1;
    int CurrentIndex = -1;
    protected void LOC_LIST2_SelectedIndexChanged(object sender, EventArgs e)
    {
        PreviousIndex = CurrentIndex;
        CurrentIndex = myDropdownList.Position; // Or whatever the get position is.
        if (CheckBoxList2.Items.Count > 0)
        {
            Label7.Visible = true;
            Label7.Text = "*Save List Before Proceeding";
        }
    }
