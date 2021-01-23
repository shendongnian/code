    double myDouble;
    try
    {
        myDouble = double.parse(textbox.Text)
    }
    catch (Exception e)
    {
        MessageBox.Show("Input is incorrect", "Error")
    }
