    private string previousValue;
    Private void comboboxChanged(object sender, EventArgs e)
    {
        if (combobox.Text == "A" && previousValue == "A")
            {
                //Do nothing
                previousValue = "A";
            }
        else if (combobox.Text == "B" && previousValue == "B")
            {
                //Do Nothing
                previousValue = "B";
            }
        else if (combobox.Text == "A")
            {
                //Do Something
                previousValue = "A";
            }
        else if (combobox.Text == "B")
            {
                //Do Something
                previousValue = "B";
            }
    }
