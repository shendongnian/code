    public void HideShape()
    {
        if (this.TangibleShape != null)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 1.0;
            animation.To = 0.0;
            animation.AutoReverse = false;
            animation.Duration = TimeSpan.FromSeconds(1.5);
            animation.FillBehavior = FillBehavior.Stop; // needed
            Storyboard s = new Storyboard();
            s.Children.Add(animation);
            Storyboard.SetTarget(animation, this.TangibleShape.Shape);
            Storyboard.SetTargetProperty(animation, new PropertyPath(ScatterViewItem.OpacityProperty));
            s.Completed += delegate(object sender, EventArgs e)
            {
                // call UIElementManager to finally hide the element
                UIElementManager.GetInstance().Hide(this.TangibleShape);
                this.TangibleShape.Shape.Opacity = 0.0; // otherwise Opacity will be reset to 1
            };
            s.Begin(this.TangibleShape.Shape); // moved to the end
        }
    }
