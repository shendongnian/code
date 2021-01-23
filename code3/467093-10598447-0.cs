       List<Button> buttons = new List<Button>();
        foreach (var bt in panel1.Controls)
        {
            if (bt is Button)
            {
               buttons.Add(bt);
            }
        }
        int btext = 1;
        foreach (var button in buttons)
        {
            button.Text = btext.ToString();
            button.BackColor = Color.White;
            btext++;
        }
