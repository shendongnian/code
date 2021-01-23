    label1.Text = "You are getting "; //Change the Text property of label1 to "You are getting "
    checkedListBox1.ItemCheck += new ItemCheckEventHandler(checkedListBox1_ItemCheck); //Link the ItemCheck event of checkedListBox1 to checkedListBox1_ItemCheck
    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.NewValue == CheckState.Checked && e.CurrentValue == CheckState.Unchecked) //Continue if the new CheckState value of the item is changing to Checked
        {
            label1.Text += "a " + checkedListBox1.Items[e.Index].ToString() +", "; //Append ("a " + the item's value + ", ") to the label1 Text property
        }
        else if (e.NewValue == CheckState.Unchecked && e.CurrentValue == CheckState.Checked) //Continue if the new CheckState value of the item is changing to Unchecked
        {
            label1.Text =  label1.Text.Replace("a " +checkedListBox1.Items[e.Index].ToString() + ", ", ""); //Replace ("a " + the item's value + ", ") with an empty string and assign this value to the label1 Text property
        }
    }
