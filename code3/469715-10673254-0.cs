    int height;
    int width;
    if (string.IsNullOrWhiteSpace(txtInputA.Text) || string.IsNullOrWhiteSpace(txtInputB.Text))
    {
        // Get values from text boxes
        height = Convert.ToInt32(txtInputA.Text);
        width = Convert.ToInt32(txtInputB.Text);
    }
    else
    {
        MessageBox.Show("Please Enter Height and Width!");
    }
