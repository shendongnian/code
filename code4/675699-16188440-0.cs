    foreach (Button button in flowLayoutPanel1.Controls)
    {    
        if (button.Name == Convert.ToString(t))
        {
            if (st == 0)
            {
               button.BackColor = Color.Red;
            }                    
            else
            {
               button.BackColor = Color.Green;
            }
        }
    }
