    private textBoxTextChanged(obj sender, EventArgs e)
    {
        foreach(UserControl uc in flowLayoutPanel.Children)
        {
            if(!uc.Text.Contains(textBox.Text) && !uc.Description.Contains(textBox.Text))
            {
                uc.Visibility = Visibility.Collapsed;
            }
            else
            {
                //Set Visible if it DOES match
                uc.Visibility = Visibility.Visible;
            }
        }
    }
