     for (int i = 0; i <= 99; i++)
     {
        TextBox tb = new TextBox();
        tb.MaxLength = (1);
        tb.Width = Unit.Pixel(40);
        tb.Height = Unit.Pixel(40);
        tb.ID = i.ToString(); // giving each textbox a different id  00-99 
        Panel1.Controls.Add(tb);
        tb.Enabled = false;
        tb.Text = daoCrossword.GetPuzzle(tb.ID).ToString();
        Literal lc = new Literal();
        lc.Text = "<br />";
        Panel1.Controls.Add(lc);
    }
