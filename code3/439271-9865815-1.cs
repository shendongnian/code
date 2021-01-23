    double value;
    if (double.TryParse(txtBox.Text, out value))
    {
        txtBox.Text = String.Format("...", value);
    }
    else
    {
        // Some code to handle the bad input (not parsable to double)
    }
