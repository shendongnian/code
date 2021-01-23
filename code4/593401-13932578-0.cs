    this.Controls.OfType<Button>().ToList().ForEach(button =>
    {
        button.Tag = new Stopwatch();
        button.MouseDown += new MouseEventHandler(button_MouseDown);
        button.MouseUp += new MouseEventHandler(button_MouseUp);
    });
