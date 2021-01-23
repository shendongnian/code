    var buttons = panel1.Controls.OfType<Button>()
                 .Select((b, i) => new { Button = b, Position = i + 1 });
    foreach(var btn in buttons)
    {
        btn.Button.Text = btn.Position.ToString();
        btn.Button.BackColor = Color.White;
    }
