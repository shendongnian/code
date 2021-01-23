    void ButtonClicked(object sender, EventArgs e)
    {
        // do stuff
    }
    // Somewhere else in your code:
    button1.Click += new EventHandler(ButtonClicked);
    // call the event handler directly:
    ButtonClicked(button1, EventArgs.Empty);
