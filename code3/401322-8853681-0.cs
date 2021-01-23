    DoubleAnimation blurEffectAnimation = new DoubleAnimation
    {
      From = 0,
      To = 10,
      Duration = TimeSpan.FromSeconds(2.0)
    };
    
    Storyboard.SetTarget(
      blurEffectAnimation, 
      Marker);
    
    Storyboard.SetTargetProperty(
      blurEffectAnimation,
      new PropertyPath("(Effect).Radius"));
    
    Storyboard sb = new Storyboard();
    
    sb.Children.Add(blurEffectAnimation);
    sb.Begin();
