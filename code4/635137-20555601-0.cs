    private void myNumericUpDown_Validated(object sender, EventArgs e)
    {
        if (myNumericUpDown.Text == "")
        {
            myNumericUpDown.Text = "0";
        }
    }
