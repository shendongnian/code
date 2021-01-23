    private void map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                clickTimer.Start();
            }
    
    private void map_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                clickTimer.Stop();
    
                if (clickTimer.ElapsedMilliseconds < arbitraryConstant) // I find that 100 works well
                {
                    Point mousePosition = e.GetPosition(this);
                    Location pinLocation = map.ViewportPointToLocation(mousePosition);
    
                    targetPin.Location = pinLocation;
    
                    map.Children.Add(targetPin);
                }
    
                clickTimer.Reset();
            }
