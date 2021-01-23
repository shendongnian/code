    private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
      var storyBoard = new Storyboard { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 250)) };
    
      // Top
      var aniTop = new DoubleAnimationUsingKeyFrames { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 250)) };
      aniTop.KeyFrames.Add(new EasingDoubleKeyFrame(Top, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 00))));
      aniTop.KeyFrames.Add(new EasingDoubleKeyFrame(10, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 250))));
      Storyboard.SetTarget(aniTop, this);
      Storyboard.SetTargetProperty(aniTop, new PropertyPath(NativeWindowSizeManager.NativeWindowTopProperty));
      storyBoard.Children.Add(aniTop);
    
      // Left
      var aniLeft = new DoubleAnimationUsingKeyFrames { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 250)) };
      aniLeft.KeyFrames.Add(new EasingDoubleKeyFrame(Left, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 00))));
      aniLeft.KeyFrames.Add(new EasingDoubleKeyFrame(10, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 250))));
      Storyboard.SetTarget(aniLeft, this);
      Storyboard.SetTargetProperty(aniLeft, new PropertyPath(NativeWindowSizeManager.NativeWindowLeftProperty));
      storyBoard.Children.Add(aniLeft);
      storyBoard.Begin();
    }
