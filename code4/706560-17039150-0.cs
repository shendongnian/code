    private void CheckedListBoxItemCheck(object sender, ItemCheckEventArgs e)
    {
        var value = checkedListBox1.Items[e.Index].ToString();
    
        if (value == "Value 1" && e.NewValue == CheckState.Checked)
        {
            Label1.Text = "Value 1";
            Textbox1.Enabled = true;
        }
        else
        {
            //disable
            Label1.Text = "Label 1";
            Textbox1.Enabled = false;
        }
    }
