    Control userControl = Page.LoadControl(control);
    Page.Controls.Add(userControl);
    if (userControl is ICustomControl)
    {
        ICustomControl customControl = userControl as ICustomControl;
        customControl.SomeProperty = "Hello, world!";
    }
