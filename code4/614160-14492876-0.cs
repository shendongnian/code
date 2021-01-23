    Button[] greenButtons = new Button[0]; // buttons to color in green
    bool enabled = true; // value of Enabled for each of addButtons() to set
    if (button1.Text == "X" & button2.Text == "X" & button3.Text == "X")
    {
        greenButtons = new[] { button1, button2, button3 };
        enabled = false;
    }
    else if (button1.Text == "X" & button4.Text == "X" & button7.Text == "X")
    {
        greenButtons = new[] { button1, button4, button7 };
        enabled = false;
    }
    else if (button1.Text == "X" & button5.Text == "X" & button9.Text == "X")
    {
        greenButtons = new[] { button1, button4, button7 };
        enabled = false;
    }
    foreach (Button button in addButton())
    {
        button.Enabled = enabled;
    }
    foreach (Button button in greenButtons)
    {
        button.BackColor = Color.Green;
    }
