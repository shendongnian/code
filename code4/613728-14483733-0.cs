    private void setButtons(List<string> labels, Button[] buttons)
    {
        for (int i = 0; i < buttons.Count(); i++)
        {
            Button button = buttons[i];
            if (i < labels.Count)
            {
                button.Text = labels[i].Trim(); // trim text here
                // button.TextAlign = ContentAlignment.MiddleCenter;
                button.Enabled = true;
            }
            else
            {
                button.Text = "";
                button.Enabled = false;
            }
        }
    }
