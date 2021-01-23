    void ClearScreen()
    {
        List<Button> _buttons = new List<Button>();
        foreach (Control c in this.Controls)
        {
            if (c is Button)
                _buttons.Add((Button)c);
        }
        foreach(var button in _buttons)
        {
            this.Controls.Remove(button);
        }
    }
