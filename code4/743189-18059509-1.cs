    public Simple()
    {
        Text = "Server Command Line";
        ...
    
        TextBox txt = new TextBox ();
        txt.Location = new Point (20, Size.Height - 70);
        txt.Size = new Size (600, 30);
        txt.KeyUp += TextBoxKeyUp; //here we attach the event
        txt.Parent = this;    
    
        Button button = new Button();
        ...
    }
    
    private void TextBoxKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            //Do something
            e.Handled = true;
        }
    }
