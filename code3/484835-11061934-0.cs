    private void CreateAButton()
    {
        var button = new ImageButton();
        button.ImageUrl = "yourimage.png";
        button.ID = "Button1";
        button.Click += ButtonClick;
        Page.Form.Controls.Add(button);
    }
    private void ButtonClick(object sender, ImageClickEventArgs e)
    {
        // Do stuff here
        // ...
    }
