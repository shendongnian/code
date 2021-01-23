    protected override void Display_OnClick(object sender, EventArgs e) {
        var buttonName = ((Button)sender).Name; // gets the name of the button that triggered this event
        var displayControl = new DisplayControl(); // your user control
        displayControl.param = buttonName; // set the desired property on your display control to the name of the button that was clicked
        ((Canvas)Content).Children.Add(displayControl); // 'Content' is your Canvas element
    }
