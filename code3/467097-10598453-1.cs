    foreach (var btn in buttons.Reverse())
    {
        btn.Button.Text = btn.Position.ToString();
        btn.Button.BackColor = Color.White;
    }
