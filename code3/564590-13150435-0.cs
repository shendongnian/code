    Button[] buttons = null;  // Initialize somewhere with all the buttons.
    void OnButtonClick(object sender, EventArgs e)
    {
        for (int index = 0; index < buttons.Length; index++)
        {
            if (buttons[index] == sender)
            {
                buttons[index].Enabled = buttons[index].Visible = false;
            }
            else
            {
                buttons[index].Enabled = buttons[index].Visible = true;
            }
        }
    }
