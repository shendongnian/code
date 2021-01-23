    public void ItemFlyIn()
    {
      if (_popupCanvas.Children.Count != 2)
        return;
    
      _popup.IsOpen = true;
      _backgroundMask.Opacity = 0.0;
    
      Image animatedImage = _popupCanvas.Children[1] as Image;
    
      var sb = new Storyboard();
      
      var rootFame =  Application.Current.RootVisual as FrameworkElement; //new line
      var targetElementPosition = _element.GetRelativePosition(rootFame); //new line
      // animate the X position
      var db = CreateDoubleAnimation(targetElementPosition.X - 100, targetElementPosition.X,
          new SineEase(),
          _targetElementClone, Canvas.LeftProperty, _flyInSpeed); //reference changed!
      sb.Children.Add(db);
    
      // animate the Y position
      db = CreateDoubleAnimation(targetElementPosition.Y - 50, targetElementPosition.Y,
          new SineEase(),
          _targetElementClone, Canvas.TopProperty, _flyInSpeed); //reference changed!
      sb.Children.Add(db);
      //other code is the same
