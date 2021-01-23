    try
    {
        tab.MouseDown -= new MouseEventHandler(this.YourMouseDownEvent);
        tab.MouseClick -= new MouseEventHandler(this.YourMouseClickEvent);
        ..... // your code here.....
    }
    finally
    {
        tab.MouseDown += new MouseEventHandler(this.YourMouseDownEvent);
        tab.MouseClick += new MouseEventHandler(this.YourMouseClickEvent);
    }
