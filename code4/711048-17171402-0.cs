      public static void Translate(this Window element, double x, double y, TimeSpan duration)
      {
         var xAnimation = new DoubleAnimationUsingKeyFrames { Duration = duration };
         xAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(element.Left, KeyTime.FromPercent(0.0)));
         xAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(x, KeyTime.FromPercent(1.0)));
    
         var yAnimation = new DoubleAnimationUsingKeyFrames { Duration = duration };
         yAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(element.Top, KeyTime.FromPercent(0.0)));
         yAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(y, KeyTime.FromPercent(1.0)));
    
         Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(Window.Left)"));
         Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(Window.Top)"));
    
         var storyboard = new Storyboard
         {
            Children = { yAnimation, xAnimation },
            Duration = duration,
            FillBehavior = FillBehavior.Stop,
         };
    
         storyboard.Completed += (sender, args) =>
         {
            storyboard.SkipToFill();
            storyboard.Remove(element);
    
            element.InvalidateProperty(Window.LeftProperty);
            element.InvalidateProperty(Window.TopProperty);
    
            if (Math.Abs(element.Left - x) > Double.Epsilon || Math.Abs(element.Top - y) > Double.Epsilon)
               Translate(element, x, y, TimeSpan.FromTicks(Math.Min(duration.Ticks / 2, 100)));
         };
    
         element.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, new Action(() => element.BeginStoryboard(storyboard)));
      }
