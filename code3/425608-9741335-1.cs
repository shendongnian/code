    void Window_ManipulationStarting(
        object sender, ManipulationStartingEventArgs e)
    {
        e.ManipulationContainer = this;
        e.Handled = true;
    }
    void Window_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
    {
        // uses the scaling value to supply the Zoom amount
        this.Map.Zoom = e.DeltaManipulation.Scale.X;
        e.Handled = true;
    }
    void Window_InertiaStarting(
        object sender, ManipulationInertiaStartingEventArgs e)
    {
        // Decrease the velocity of the Rectangle's resizing by 
        // 0.1 inches per second every second.
        // (0.1 inches * 96 pixels per inch / (1000ms^2)
        e.ExpansionBehavior.DesiredDeceleration = 0.1 * 96 / (1000.0 * 1000.0);
        e.Handled = true;
    }
