    int windowX, windowY;
    
    if (Int32.TryParse(txtX.Text, out windowX) &&
        Int32.TryParse(txtY.Text, out windowY))
    {
        this.Location = new System.Drawing.Point(windowX, windowY);
    }
    else
    {
        // Tell the user they didn't enter a valid number
    }
