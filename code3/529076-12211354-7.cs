        if (test == 1)
        {
           txtControl.Text = "150";
        }
        else if (test == 2)
        {
            txtControl.Text = "150";
        }
        else
        {
            txtControl.Text = "250";
        }
    Implement it as:
        if (test == 1 || test == 2)
        {
           txtControl.Text = "150";
        }
        else
        {
           txtControl.Text = "250";
        }
