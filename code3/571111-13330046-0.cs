    private Rectangle[] ControlsToAnimate;
    private int CurrentIndex;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.ControlsToAnimate = new[] { this.Rectangle1, this.Rectangle2 };
        this.Storyboard1.Completed += StoryboardCompleted;
        this.AnimateNextControl();
    }
    private void AnimateNextControl()
    {
        if (this.CurrentIndex >= this.ControlsToAnimate.Length)
        {
            this.CurrentIndex = 0;
            return;
        }
        var nextControl = this.ControlsToAnimate[this.CurrentIndex];
        this.CurrentIndex++;
        this.Storyboard1.Stop();
        this.Storyboard1.SetValue(Storyboard.TargetNameProperty, nextControl.Name);
        this.Storyboard1.Begin();
    }
    private void StoryboardCompleted(object sender, EventArgs e)
    {
        this.AnimateNextControl();
    }
