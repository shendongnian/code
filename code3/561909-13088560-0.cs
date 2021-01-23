    Form Form1;
    button.Click += click;
    
    private void click(object s, EventArgs e)
    {
        if(Form1.ModifierKeys == Keys.Control)
        ... // Whatever you need here
    }
