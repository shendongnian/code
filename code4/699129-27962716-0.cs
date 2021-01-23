    {
        this.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Image = YourResources.split_button; // Your down-arrow image
    
        this.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
    }
    
    
    protected override void OnClick(EventArgs e)
    {
        var clickPos = this.PointToClient(new System.Drawing.Point(MousePosition.X, MousePosition.Y));
    
        // If click is over the right-hand portion of the button show the menu
        if (clickPos.X > (Size.Width - Image.Width))
            ShowMenuUnderControl()
        else
            base.OnClick(e);
    }
    
    // If you want right-mouse click to invoke the menu
    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        if ((mevent.Button & MouseButtons.Right) != 0)
            ShowMenuUnderControl();
        else
            base.OnMouseDown(mevent);
    }
    
    // Raise the context menu
    public void ShowMenuUnderControl()
    {
        splitMenuStrip.Show(this, new Point(0, this.Height), ToolStripDropDownDirection.BelowRight);
    }
