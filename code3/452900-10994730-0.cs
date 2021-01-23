    protected override void OnOrientationChanged(OrientationChangedEventArgs e)
    {
      base.OnOrientationChanged(e);
      switch (e.Orientation)
      {
        case PageOrientation.Landscape:
        case PageOrientation.LandscapeLeft:
          videoBrushTransform.Rotation = 0;
          break;
        case PageOrientation.LandscapeRight:
          videoBrushTransform.Rotation = 180;
          break;
        case PageOrientation.Portrait:
        case PageOrientation.PortraitUp:
          videoBrushTransform.Rotation = 90;
          break;
        case PageOrientation.PortraitDown:
          videoBrushTransform.Rotation = 270;
          break;
      }
    }
