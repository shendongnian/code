    Button.MouseEnter += new EventHandler(delegate(object Sender, EventArgs e) { Button.Size = new Size(Button.Size.Width + 50, Button.Size.Height + 50); } Button.Location = new Point(Button.Location.X - (50 / 2), Button.Location.Y - (50 / 2)});
    Button.MouseLeave += new EventHandler(delegate(object Sender, EventArgs e) { Button.Size = new Size(Button.Size.Width - 50, Button.Size.Height - 50 }; Button.Location = new Point(Button.Location.X + (50 / 2), Button.Location.Y + (50 / 2)});
    
    Button.GotFocus +=  new EventHandler(delegate(object Sender, EventArgs e) { Button.Size = new Size(Button.Size.Width + 50, Button.Size.Height + 50); } Button.Location = new Point(Button.Location.X - (50 / 2), Button.Location.Y - (50 / 2)});
    Button.LostFocus += new EventHandler(delegate(object Sender, EventArgs e) { Button.Size = new Size(Button.Size.Width - 50, Button.Size.Height - 50 }; Button.Location = new Point(Button.Location.X + (50 / 2), Button.Location.Y + (50 / 2)});
