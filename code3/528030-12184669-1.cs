    void StuffThatHappensOnButtonClick()
    {
        // do stuff
    }
    void ButtonClicked(object sender, EventArgs e)
    {
        StuffThatHappensOnButtonClick();
    }
    // Somewhere else in your code:
    button1.Click += new EventHandler(ButtonClicked);
    // Simulate the button click:
    StuffThatHappensOnButtonClick();
