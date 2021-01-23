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
    
    
    // Raise the context menu
    public void ShowMenuUnderControl()
    {
        splitMenuStrip.Show(this, new Point(0, this.Height), ToolStripDropDownDirection.BelowRight);
    }
