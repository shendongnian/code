    Image img = Image.FromFile("URL");
    foreach(Control ctrl in this.Controls)
    {
        if(ctrl is Button)
        {
            Button btn = (Button)ctrl;
            if(/* test if this button should be used */)
            {
                btn.BackgroundImage=img;
            }
        }
    }
