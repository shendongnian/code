        // Remove mouse navigation
        plotter.Children.Remove(plotter.MouseNavigation);
        // ZoomX when wheeling mouse
        private void plotter_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (!e.Handled)
            {
                Point mousePos = e.GetPosition(this);
                Point zoomTo = mousePos.ScreenToViewport(plotter.Viewport.Transform);
                double zoomSpeed = Math.Abs(e.Delta / Mouse.MouseWheelDeltaForOneLine);
                zoomSpeed *= 1.2;
                if (e.Delta < 0)
                {
                    zoomSpeed = 1 / zoomSpeed;
                }
                plotter.Viewport.SetChangeType(ChangeType.Zoom);
                plotter.Viewport.Visible = plotter.Viewport.Visible.ZoomX(zoomTo, zoomSpeed);
                plotter.Viewport.SetChangeType();
                e.Handled = true;
            }
        }
