    private void timer_Tick(object sender, EventArgs e)
    {
        var hoverOpacity = this.opbHover.Opacity + this._animationDirection;
        if (hoverOpacity < OpacityPictureBox.MinOpacity ||
            hoverOpacity > OpacityPictureBox.MaxOpacity)
        {
            this.timer.Stop();
            return;
        }
        this.opbHover.Opacity = hoverOpacity;
    }
