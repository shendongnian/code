    private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        Location loc = AustralianMap.ViewportPointToLocation(e.GetPosition(AustralianMap));
        System.Diagnostics.Trace.TraceInformation("Hit location {0}", loc);
    }
