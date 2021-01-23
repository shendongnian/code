    protected override Size ArrangeOverride(Size finalSize)
    {
        var adornedElement = this.AdornedElement as FrameworkElement;
        // Use the width/height etc of adorned element to arrange the thumbs here
        // Its been a long time so either its width/height or actualwidth/actualheight
        // you will need to use.
        this._leftTopThumb.Arrange(Get the Rect To arrange here);  
        this._rightTopThumb.Arrange(Get the Rect To arrange here); 
        // etc
        return finalSize;
    }
