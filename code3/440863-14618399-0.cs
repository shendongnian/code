    Vector _mouseToMarker;
    private bool _dragPin;
    public Pushpin SelectedPushpin { get; set; }
    void pin_MouseDown(object sender, MouseButtonEventArgs e)
    {
      e.Handled = true;
      SelectedPushpin = sender as Pushpin;
      _dragPin = true;
      _mouseToMarker = Point.Subtract(
        map.LocationToViewportPoint(SelectedPushpin.Location), 
        e.GetPosition(map));
    }
    private void map_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        if (_dragPin && SelectedPushpin != null)
        {
          SelectedPushpin.Location = map.ViewportPointToLocation(
            Point.Add(e.GetPosition(map), _mouseToMarker));
          e.Handled = true;
        }
      }
    }
