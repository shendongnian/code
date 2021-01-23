    void HideDefaultScreenImageTimer_Tick(object sender, EventArgs e)
    {
        HideDefaultScreenImageTimer.Stop();
    
        var doubleAnimation = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(0.45)));
        doubleAnimation.Completed += (sender, eArgs) => MainCanvas.Children.Remove(DefaultScreenImage);
    
        DefaultScreenImage.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
        
    }
