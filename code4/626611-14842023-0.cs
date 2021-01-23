    button.Click += new System.EventHandler(ButtonClick);
    button1.Click += new System.EventHandler(ButtonClick);
    // And for each button, one of those.
    private void ButtonClick(object sender, System.EventArgs e)
    {
    // Do whatever you want to do here, you can place the TEXT to be appended on the button, if so:
    lb1SentenceText.Text += sender.Text;
    }
