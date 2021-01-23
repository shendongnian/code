    //Get the values
        if (rblYears.SelectedIndex == 0)
            years = 15;
        else if (rblYears.SelectedIndex == 1)
            years = 30;
        else
        {
            //Display Error if custom duration is entered
            if (!double.TryParse(txtYears.Text, out years))
            {
                error = true;
                lblResult.Text = "The years must be a numeric value!";
            }
        }
